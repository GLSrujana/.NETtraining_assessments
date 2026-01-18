let age = 16;
if (age >= 18) {
 console.log("Eligible");
} else{
 console.log("Not Eligible");
}


let pwd = "admin123";
let confirmPwd = "admin123";
if (pwd == confirmPwd) {
 console.log("Match");
} else {
    console.log("Mismatch");
}

console.log("Start");
alert("Hello");
console.log("End");

let mobile = document.getElementById("mobile").value;
if (mobile.length = 10) {
    alert("Valid");
} else {
    alert("Invalid");
}

let policyNumber = 123456;
document.getElementById("policy").innerHTML = policyNumber;

let claimAmount = "abc";
if (isNaN(claimAmount)) {
    alert("Invalid claim");
} else {
    alert("Valid claim");
}


let policyType = "Health";
if (policyType == "Health") {
    console.log("Health Policy");
}


let policies = ["Life", "Health", "Vehicle"];
let list = document.getElementById("list");

policies.forEach(function (policy) {
    list.innerHTML += "<li>" + policy + "</li>";
});


let premium = "5000";

if (isNaN(Number(premium))) {
    console.log("Invalid premium");
} else {
    console.log("Valid premium");
}
