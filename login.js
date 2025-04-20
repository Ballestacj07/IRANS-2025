// Function to validate the login form
function validateLoginForm(event) {
    const studentNumber = document.querySelector('input[name="student_no"]').value;
    const password = document.querySelector('input[name="password"]').value;

    if (!studentNumber || !password) {
        alert('Please fill out both fields.');
        event.preventDefault(); // Prevent form submission
        return false;
    }
    return true;
}

// Function to handle form submission
function handleLoginFormSubmit(event) {
    if (!validateLoginForm(event)) {
        return; // Validation failed, don't submit the form
    }
    // Normally, form submission would be handled here, potentially with an AJAX call
    // For now, let's simulate successful login with an alert
    alert('Login form submitted successfully.');
}

// Add event listener to form
document.addEventListener('DOMContentLoaded', function () {
    const form = document.querySelector('form');
    form.addEventListener('submit', handleLoginFormSubmit);
});
