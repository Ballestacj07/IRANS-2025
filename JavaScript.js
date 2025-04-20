document.querySelector('form').addEventListener('submit', function (event) {
    const checkbox = document.getElementById('newsletter');
    if (!checkbox.checked) {
        event.preventDefault(); 
        alert('Please check the box to receive our newsletter.');
    }
});

function logout() {
    window.location.href = 'login.html';
}


function validateForm(event) {
    const subject = document.getElementById('subject').value;
    const name = document.getElementById('fullname').value;
    const reportDate = document.getElementById('report-date').value;
    const reportTime = document.getElementById('report-time').value;
    const incidentReport = document.getElementById('incident-report').value;

    if (!subject || !name || !reportDate || !reportTime || !incidentReport) {
        alert('Please fill out all required fields.');
        event.preventDefault(); 
        return false;
    }
    return true;
}


function confirmDelete() {
    return confirm('Are you sure you want to delete this report?');
}

function handleFormSubmit(event) {
    if (!validateForm(event)) {
        return; 
    }
    alert('Incident report logged successfully.');
}

function showAvatar(type) {
    const avatarImage = document.getElementById('avatar');
    if (type === 'male') {
        avatarImage.src = 'images/male.png'; 
    } else if (type === 'female') {
        avatarImage.src = 'images/female.png'; 
    }
}
