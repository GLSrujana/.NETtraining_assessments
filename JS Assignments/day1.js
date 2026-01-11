// Variables
let count = 10;               
const siteName = "Hartford";  
let isActive = true;          

// Operators
let result = count + 5;
console.log(result);          

// Arrow function
const greet = (name) => {
    return `Welcome to ${siteName}, ${name}!`; // Template literal
};

console.log(greet("User"));


const numbers = [10, 20, 30, 40];

// map
const doubled = numbers.map(num => num * 2);
console.log("Map:", doubled);

// filter
const aboveTwenty = numbers.filter(num => num > 20);
console.log("Filter:", aboveTwenty);

// reduce
const total = numbers.reduce((sum, num) => sum + num, 0);
console.log("Reduce:", total);

// loop
for (let i = 0; i < numbers.length; i++) {
    console.log("Loop value:", numbers[i]);
}


//    5. DOM SELECTION & MANIPULATION

// Selecting elements
const title = document.getElementById("title");
const boxes = document.querySelectorAll(".box");

// Changing content
title.textContent = "JS DOM Manipulation Example";

// Changing styles
title.style.color = "blue";

// Changing attributes
title.setAttribute("data-demo", "true");


//    6. DOM TRAVERSING

// Access first box
const firstBox = boxes[0];

// Parent element
console.log(firstBox.parentElement);

// Next sibling
console.log(firstBox.nextElementSibling);

// Child elements
console.log(firstBox.children);


//    INTERACTIVITY

const button = document.getElementById("actionBtn");

button.addEventListener("click", () => {
    firstBox.classList.toggle("highlight");
});

/* ===== BENTO GRID DATA ===== */

const grid = document.getElementById("bentoGrid");
const totalCardsEl = document.getElementById("totalCards");
const totalViewsEl = document.getElementById("totalViews");

const cardsData = [
    { id: 1, title: "UI Design", category: "design", views: 120 },
    { id: 2, title: "JavaScript Logic", category: "tech", views: 300 },
    { id: 3, title: "Startup Growth", category: "business", views: 180 },
    { id: 4, title: "CSS Animations", category: "design", views: 220 },
    { id: 5, title: "Web APIs", category: "tech", views: 260 },
    { id: 6, title: "Market Strategy", category: "business", views: 140 }
];

/* ===== RENDER GRID (map) ===== */

const renderGrid = (data) => {
    grid.innerHTML = "";

    data.map(item => {
        const card = document.createElement("div");
        card.className = "card";

        card.innerHTML = `
            <h3>${item.title}</h3>
            <p>Views: ${item.views}</p>
            <span class="category">${item.category}</span>
        `;

        grid.appendChild(card);
    });

    updateStats(data);
};

/* ===== UPDATE STATS (reduce) ===== */

const updateStats = (data) => {
    totalCardsEl.textContent = data.length;

    const totalViews = data.reduce(
        (sum, item) => sum + item.views,
        0
    );

    totalViewsEl.textContent = totalViews;
};

/* ===== FILTER LOGIC (filter) ===== */

document.querySelectorAll(".controls button").forEach(button => {
    button.addEventListener("click", () => {
        const category = button.dataset.category;

        const filtered =
            category === "all"
                ? cardsData
                : cardsData.filter(
                    item => item.category === category
                  );

        renderGrid(filtered);
    });
});

/* ===== DOM TRAVERSING ===== */

setTimeout(() => {
    const firstCard = grid.firstElementChild;
    if (firstCard) {
        firstCard.style.backgroundColor = "#e0f2fe";
    }
}, 1000);

/* ===== INITIAL LOAD ===== */

renderGrid(cardsData);
