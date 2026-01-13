document.getElementById("paymentSection").addEventListener("click", function () {
    console.log("Payment Section clicked");
});


document.getElementById("payBtn").addEventListener("click", function () {
    console.log("Pay Premium button clicked");
});


document.getElementById("policyContainer").addEventListener(
    "click",
    function () {
        console.log("Parent: Validating user before showing policy");
    },
    true 
);


document.getElementById("viewPolicyBtn").addEventListener(
    "click",
    function () {
        console.log("Child: Showing policy details");
    },
    true 
);


document.querySelector(".policyCard").addEventListener("click", function () {
    console.log("Navigating to policy details page");
});


document.querySelector(".deleteBtn").addEventListener("click", function (event) {
    event.stopPropagation(); 
    console.log("Policy deleted");
});



document.querySelectorAll(".claimRow").forEach(row => {
    row.addEventListener("click", function () {
        console.log("Opening Claim Details");
    });
});


document.querySelectorAll(".approveBtn").forEach(button => {
    button.addEventListener("click", function (event) {
        event.stopPropagation(); 
        console.log("Claim Approved");
    });
});
