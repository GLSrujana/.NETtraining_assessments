// Task 1– Select by ID
const pageTitle = document.getElementById("pageTitle");
pageTitle.textContent = "Customer Insurance Overview";

// task-2 Select by Tag Name
// Select all <li> elements
const customerItems = document.getElementsByTagName("li");

// Add border to each customer
for (let i = 0; i < customerItems.length; i++) {
  customerItems[i].style.border = "1px solid #333";
  customerItems[i].style.padding = "5px";
  customerItems[i].style.margin = "4px 0";
}

// Log total number of customers
console.log("Total Customers:", customerItems.length);


// task-3 Select by Class Name
// Select all elements with class "policy"
const policies = document.getElementsByClassName("policy");

for (let i = 0; i < policies.length; i++) {
  // Add highlight class
  policies[i].classList.add("highlight");

  // Change text color to blue
  policies[i].style.color = "blue";
}


// task-4 Select usig CSS Selectors
// Select first customer only
const firstCustomer = document.querySelector(".customer");
firstCustomer.style.backgroundColor = "#e0f7fa";

// Select all customers
const allCustomers = document.querySelectorAll(".customer");

// Mark the last customer as active
const lastCustomer = allCustomers[allCustomers.length - 1];
lastCustomer.classList.add("active");


// task-5 HTML Object Collections
// Count number of forms
const formsCount = document.forms.length;
console.log("Number of forms:", formsCount);

// Get number of images
const imagesCount = document.images.length;
console.log("Number of images:", imagesCount);

// Change text of all links to "More Info"
const links = document.links;
for (let i = 0; i < links.length; i++) {
  links[i].textContent = "More Info";
}


// task-6 Add a new customer dynamically and observe
const newCustomer = document.createElement("li");
newCustomer.className = "customer";
newCustomer.textContent = "Suresh - Health";

document.getElementById("customerList").appendChild(newCustomer)

// task-7 Attribute-Based Selection
const textInputs = document.querySelectorAll('input[type="text"]');

textInputs.forEach(input => {
  input.style.backgroundColor = "yellow";
  input.placeholder = "Enter Full Name";
});


// task-8 Multiple Class Selection
const priorityCustomers = document.querySelectorAll(".customer.active");

priorityCustomers.forEach(el => {
  el.style.color = "darkgreen";
  el.textContent += " (Priority Customer)";
});


// task-9 Descendant vs Child Selector
const descendantLis = document.querySelectorAll("#customerList li");

const childLis = document.querySelectorAll("#customerList > li");

console.log("Descendant <li> count:", descendantLis.length);
console.log("Child <li> count:", childLis.length);


// task-10 Even/Odd Selection (CSS Pseudo Selectors)
// Highlight even customers
document.querySelectorAll("#customerList li:nth-child(even)").forEach(el => {
  el.style.backgroundColor = "#f0f0f0"; // light gray
});

// Highlight odd customers
document.querySelectorAll("#customerList li:nth-child(odd)").forEach(el => {
  el.style.backgroundColor = "#e3f2fd"; // light blue
});


// task-11 Form Elements Collection
const enquiryForm = document.forms["enquiryForm"];

for (let i = 0; i < enquiryForm.elements.length; i++) {
  console.log("Form Field:", enquiryForm.elements[i].name);
}

enquiryForm.querySelector('button[type="submit"]').disabled = true;


// task-12 NodeList vs HTMLCollection
const policyHTMLCollection = document.getElementsByClassName("policy");

const policyNodeList = document.querySelectorAll(".policy");

console.log("Initial HTMLCollection:", policyHTMLCollection.length);
console.log("Initial NodeList:", policyNodeList.length);
const newPolicy = document.createElement("p");
newPolicy.className = "policy";
newPolicy.textContent = "Travel Insurance";
document.body.appendChild(newPolicy);

console.log("After Adding Policy:");
console.log("HTMLCollection (auto-updated):", policyHTMLCollection.length);
console.log("NodeList (not updated):", policyNodeList.length);


// task-13 Text Content Filtering
const allCustomerItems = document.querySelectorAll(".customer");

allCustomerItems.forEach(customer => {
  const text = customer.textContent;

  if (text.includes("Life")) {
    customer.style.backgroundColor = "#c8e6c9"; 
  }

  if (text.includes("Vehicle")) {
    customer.style.display = "none";
  }
});


// task-14 Closest and Parental Traversal
allCustomerItems.forEach(customer => {
  customer.addEventListener("click", function () {
    const nearestUL = this.closest("ul");
    nearestUL.style.border = "2px solid blue";
  });
});


// task-15 Complex Selector Challenge
const policyParagraphs = document.querySelectorAll("p:not(:first-child)");

policyParagraphs.forEach(p => {
  p.style.fontStyle = "italic";
  p.textContent = "✓ " + p.textContent;
});