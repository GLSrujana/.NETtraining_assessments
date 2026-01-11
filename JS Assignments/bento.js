const bentoGrid = document.getElementById("bentoGrid");

const bentoItems = [
    { title: "Analytics", size: "large" },
    { title: "Sales", size: "small" },
    { title: "Marketing", size: "wide" },
    { title: "Finance", size: "tall" },
    { title: "Growth", size: "small" },
    { title: "Customers", size: "large" },
    { title: "Reports", size: "wide" }
];

/* RENDER BENTO GRID (map) */
const renderBento = () => {
    bentoGrid.innerHTML = "";

    bentoItems.map(item => {
        const div = document.createElement("div");
        div.className = "bento-item";
        div.setAttribute("data-bento", item.size);

        div.innerHTML = `<h3>${item.title}</h3>`;

        bentoGrid.appendChild(div);
    });
};

renderBento();
