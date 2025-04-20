// JavaScript for form validation
function validateForm(event) {
    const name = document.querySelector('input[name="name"]').value;
    const studentNumber = document.querySelector('input[name="student_number"]').value;
    const newPassword = document.querySelector('input[name="new_password"]').value;

    // Check if any field is empty
    if (!name || !studentNumber || !newPassword) {
        alert('Please fill out all required fields.');
        event.preventDefault(); // Prevent form submission
        return false;
    }

    // Check if the password length is less than 6
    if (newPassword.length < 6) {
        alert('Password must be at least 6 characters long.');
        event.preventDefault(); // Prevent form submission
        return false;
    }

    return true;
}

// Add event listener for form submission
document.querySelector('form').addEventListener('submit', validateForm);

// Optionally, add a success alert after form submission
function handleFormSubmit(event) {
    if (validateForm(event)) {
        alert('Password reset request submitted successfully.');
    }
}
