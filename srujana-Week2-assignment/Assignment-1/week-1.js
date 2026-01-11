const form = document.getElementById("enquiryForm");

// Create success message element
const successMsg = document.createElement("p");
successMsg.style.color = "green";
successMsg.style.fontSize = "14px";
successMsg.style.textAlign = "center";
successMsg.style.marginTop = "15px";
form.appendChild(successMsg);

form.addEventListener("submit", function (e) {
    e.preventDefault(); // Task 7

    clearErrors();
    successMsg.textContent = "";

    let isValid = true;

    const name = form.elements["fullname"];
    const email = form.elements["email"];
    const mobile = form.elements["mobile"];
    const requestType = form.elements["requestType"];
    const policyType = form.elements["policyType"];
    const message = form.querySelector("textarea");
    const rating = form.elements["rating"];

    // Name validation
    if (name.value.trim() === "") {
        showError(name, "Name cannot be empty");
        isValid = false;
    }

    // Email validation
    if (email.value.trim() === "") {
        showError(email, "Email cannot be empty");
        isValid = false;
    }

    // Mobile validation (exactly 10 digits)
    if (!/^\d{10}$/.test(mobile.value.trim())) {
        showError(mobile, "Mobile number must be exactly 10 digits");
        isValid = false;
    }

    // Request Type
    if (requestType.value === "") {
        showError(requestType, "Please select a request type");
        isValid = false;
    }

    // Policy Type
    if (policyType.value === "") {
        showError(policyType, "Please select a policy type");
        isValid = false;
    }

    // Message validation
    if (message.value.trim().length < 10) {
        showError(message, "Message must be at least 10 characters");
        isValid = false;
    }

    // Rating validation
    let ratingSelected = false;
    for (let i = 0; i < rating.length; i++) {
        if (rating[i].checked) {
            ratingSelected = true;
            break;
        }
    }

    if (!ratingSelected) {
        showError(rating[rating.length - 1].parentElement, "Please select a rating");
        isValid = false;
    }

    // Success
    if (isValid) {
        successMsg.textContent = "Thank you! Your enquiry has been successfully submitted.";
        form.reset();
    }
});

// Show error below field
function showError(element, message) {
    const error = document.createElement("div");
    error.className = "error";
    error.textContent = message;

    element.parentNode.insertBefore(error, element.nextSibling);
}

// Clear old errors
function clearErrors() {
    const errors = document.querySelectorAll(".error");
    errors.forEach(err => err.remove());
}
