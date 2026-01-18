document.addEventListener("DOMContentLoaded", () => {

const API_URL = "https://jsonplaceholder.typicode.com/users";
const MIN_BALANCE = 5000;
const PENALTY_AMOUNT = 200;
const STORAGE_KEY = "bank_accounts";

let accounts = [];


function saveToStorage() {
  localStorage.setItem(STORAGE_KEY, JSON.stringify(accounts));
}

function loadFromStorage() {
  const data = localStorage.getItem(STORAGE_KEY);
  return data ? JSON.parse(data) : null;
}


function generateBalance() {
  return Math.floor(Math.random() * (50000 - 10000 + 1)) + 10000;
}


async function loadAccounts() {
  const loader = document.getElementById("loader");
  const errorMsg = document.getElementById("errorMsg");

  loader.style.display = "block";
  errorMsg.style.display = "none";

  const stored = loadFromStorage();

  if (stored) {
    accounts = stored.map(acc => ({
      ...acc,
      transactions: acc.transactions || [] 
    }));
    populateCityDropdown();
    renderAccounts(accounts);
    loader.style.display = "none";
    return;
  }

  try {
    const res = await fetch(API_URL);
    if (!res.ok) throw new Error("API error");

    const users = await res.json();

    accounts = users.map(u => ({
      ...u,
      balance: generateBalance(),
      transactions: []
    }));

    saveToStorage();
    populateCityDropdown();
    renderAccounts(accounts);
  } catch (e) {
    errorMsg.style.display = "block";
  } finally {
    loader.style.display = "none";
  }
}


function populateCityDropdown() {
  const citySelect = document.getElementById("cityFilter");
  const cities = ["All", ...new Set(accounts.map(a => a.address.city))];

  citySelect.innerHTML = "";
  cities.forEach(c => {
    const o = document.createElement("option");
    o.value = c;
    o.textContent = c;
    citySelect.appendChild(o);
  });
}

function applyFilters() {
  const search = document.getElementById("searchInput").value.toLowerCase();
  const city = document.getElementById("cityFilter").value;

  const filtered = accounts.filter(a =>
    a.name.toLowerCase().includes(search) &&
    (city === "All" || a.address.city === city)
  );

  renderAccounts(filtered);
}

document.getElementById("searchInput").addEventListener("input", applyFilters);
document.getElementById("cityFilter").addEventListener("change", applyFilters);


function sortByBalance() {
  accounts.sort((a, b) => b.balance - a.balance);
  saveToStorage();
  applyFilters();
}

function showTotalBalance(data) {
  const total = data.reduce((sum, a) => sum + a.balance, 0);
  document.getElementById("totalBalance").textContent =
    `🏦 Total Bank Balance: ₹${total}`;
}


function renderAccounts(data) {
  const tbody = document.getElementById("accountTable");
  tbody.innerHTML = "";

  if (!data.length) {
    tbody.innerHTML = `<tr><td colspan="6">No accounts</td></tr>`;
    return;
  }

  showTotalBalance(data);

  data.forEach(acc => {
    const low = acc.balance < MIN_BALANCE ? 'style="background:#ffe5e5"' : "";

    tbody.innerHTML += `
      <tr ${low}>
        <td>${acc.id}</td>
        <td>${acc.name}</td>
        <td>${acc.email}</td>
        <td>${acc.address.city}</td>
        <td>₹${acc.balance}</td>
        <td>
          <button onclick="deposit(${acc.id})">Deposit</button>
          <button onclick="withdraw(${acc.id})">Withdraw</button>
          <button onclick="viewTransactions(${acc.id})">History</button>
          <button onclick="deleteAccount(${acc.id})">Delete</button>
        </td>
      </tr>
    `;
  });
}


window.deposit = function (id) {
  const amt = Number(prompt("Enter deposit amount"));
  if (amt <= 0 || isNaN(amt)) return alert("Invalid");

  const acc = accounts.find(a => a.id === id);
  acc.balance += amt;

  acc.transactions.push({
    type: "Deposit",
    amount: amt,
    time: new Date().toLocaleString()
  });

  saveToStorage();
  applyFilters();
};


window.withdraw = function (id) {
  const amt = Number(prompt("Enter withdrawal amount"));
  if (amt <= 0 || isNaN(amt)) return alert("Invalid");

  const acc = accounts.find(a => a.id === id);
  if (amt > acc.balance) return alert("Insufficient balance");

  acc.balance -= amt;

  acc.transactions.push({
    type: "Withdraw",
    amount: amt,
    time: new Date().toLocaleString()
  });

  if (acc.balance < MIN_BALANCE) {
    acc.balance -= PENALTY_AMOUNT;
    acc.transactions.push({
      type: "Penalty",
      amount: PENALTY_AMOUNT,
      time: new Date().toLocaleString()
    });
    alert("⚠ ₹200 penalty applied");
  }

  saveToStorage();
  applyFilters();
};


window.viewTransactions = function (id) {
  const acc = accounts.find(a => a.id === id);
  if (!acc.transactions.length) return alert("No transactions");

  alert(
    acc.transactions
      .map(t => `${t.time} | ${t.type} | ₹${t.amount}`)
      .join("\n")
  );
};


window.deleteAccount = function (id) {
  if (!confirm("Delete account?")) return;
  accounts = accounts.filter(a => a.id !== id);
  saveToStorage();
  populateCityDropdown();
  applyFilters();
};


document.getElementById("createAccountForm").addEventListener("submit", e => {
  e.preventDefault();

  const name = document.getElementById("name").value.trim();
  const email = document.getElementById("email").value.trim();
  const branch = document.getElementById("branch").value.trim();

  const acc = {
    id: Date.now(),
    name,
    email,
    address: { city: branch },
    balance: 20000,
    transactions: []
  };

  accounts.unshift(acc);
  saveToStorage();
  populateCityDropdown();
  applyFilters();
  e.target.reset();
});


loadAccounts();

});
