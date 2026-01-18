// API URL
const API_URL = "https://dummyjson.com/products";

// Table body where products will be shown
const tableBody = document.getElementById("productTableBody");

// Fetch and display products
function fetchProducts() {
    fetch(API_URL)
        .then(response => response.json())
        .then(data => {
            const products = data.products; // IMPORTANT
            tableBody.innerHTML = ""; // Clear table first

            products.forEach(product => {
                const row = document.createElement("tr");

                row.innerHTML = `
                    <td>${product.id}</td>
                    <td>${product.title}</td>
                    <td>${product.price}</td>
                    <td>${product.category}</td>
                    <td>${product.description}</td>
                    <td>
                        <button class="action-btn edit-btn">Edit</button>
                        <button class="action-btn delete-btn">Delete</button>
                    </td>
                `;

                tableBody.appendChild(row);
            });
        })
        .catch(error => {
            console.error("Error fetching products:", error);
        });
}

// Call function when page loads
fetchProducts();
