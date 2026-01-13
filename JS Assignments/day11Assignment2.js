const paymentSection = document.getElementById("paymentSection");
const payBtn = document.getElementById("payBtn");

// Click event on div
paymentSection.addEventListener("click", () => {
  console.log("Payment Section clicked");
});

// Click event on button
payBtn.addEventListener("click", () => {
  console.log("Pay Premium button clicked");
});
