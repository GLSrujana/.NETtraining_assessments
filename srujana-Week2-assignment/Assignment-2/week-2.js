const plans = [
  { type: "Health", base: 3000, coverage: "Up to 10 Lakhs" },
  { type: "Life", base: 5000, coverage: "Up to 20 Lakhs" },
  { type: "Vehicle", base: 2000, coverage: "Up to 5 Lakhs" }
];

let customers = [];


const plansDiv = document.getElementById("plans");
const policySelect = document.getElementById("policyType");
const filterPolicy = document.getElementById("filterPolicy");
const basePremiumText = document.getElementById("basePremium");
const coverage = document.getElementById("coverage");
const coverageValue = document.getElementById("coverageValue");
const table = document.getElementById("customerTable");
const totalCustomers = document.getElementById("totalCustomers");
const totalPremium = document.getElementById("totalPremium");
const search = document.getElementById("search");


plansDiv.innerHTML = plans.map(p => `
  <div class="card">
    <h3 class="text-xl font-semibold">${p.type} Insurance</h3>
    <p class="mt-2 text-sm">Base Premium: ₹${p.base}</p>
    <p class="text-sm">Coverage: ${p.coverage}</p>
    <button class="btn-primary mt-4 w-full">Enroll</button>
  </div>
`).join("");


plans.forEach(p => {
  policySelect.innerHTML += `<option value="${p.type}">${p.type}</option>`;
  filterPolicy.innerHTML += `<option value="${p.type}">${p.type}</option>`;
});


policySelect.addEventListener("change", () => {
  const plan = plans.find(p => p.type === policySelect.value);
  basePremiumText.textContent = plan ? plan.base : 0;
});

coverage.addEventListener("input", () => {
  coverageValue.textContent = coverage.value;
});


function calculatePremium(age, policyType, coverage) {
  let base = plans.find(p => p.type === policyType).base;
  if (age > 45) base *= 1.2;
  return Math.round(base + (coverage - 1) * 500);
}


document.getElementById("customerForm").addEventListener("submit", e => {
  e.preventDefault();

  const customer = {
    name: name.value,
    age: +age.value,
    policyType: policySelect.value,
    coverage: +coverage.value,
    premium: calculatePremium(+age.value, policySelect.value, +coverage.value)
  };

  customers.push(customer);
  e.target.reset();
  basePremiumText.textContent = 0;
  coverageValue.textContent = 1;
  render();
});


function render() {
  const filtered = customers
    .filter(c => c.name.toLowerCase().includes(search.value.toLowerCase()))
    .filter(c => !filterPolicy.value || c.policyType === filterPolicy.value);

  table.innerHTML = filtered.map(c => `
    <tr class="border-t">
      <td class="p-2">${c.name}</td>
      <td class="p-2">${c.age}</td>
      <td class="p-2">${c.policyType}</td>
      <td class="p-2">${c.coverage}</td>
      <td class="p-2">₹${c.premium}</td>
    </tr>
  `).join("");

  totalCustomers.textContent = customers.length;
  totalPremium.textContent = customers.reduce((sum, c) => sum + c.premium, 0);
}

search.addEventListener("input", render);
filterPolicy.addEventListener("change", render);
