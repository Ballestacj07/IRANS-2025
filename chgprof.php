<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Change Profile Picture</title>
    <link href="css/chgprof.css" rel="stylesheet" />
    <script>
        function logout() {
            window.location.href = 'login.php'; 
        }

        function updateAvatar(type) {
            const avatarImage = document.getElementById('avatar');
            const hiddenAvatarField = document.getElementById('selected-avatar');

            if (type === 'male') {
                avatarImage.src = 'images/male.png'; // Path to the male avatar image
                hiddenAvatarField.value = 'male.png'; // Store the choice
            } else if (type === 'female') {
                avatarImage.src = 'images/female.png'; // Path to the female avatar image
                hiddenAvatarField.value = 'female.png'; // Store the choice
            }
        }

        function previewImage(event) {
            const reader = new FileReader();
            const avatarImage = document.getElementById('avatar');

            reader.onload = function () {
                if (reader.readyState === 2) {
                    avatarImage.src = reader.result; 
                }
            };

            reader.readAsDataURL(event.target.files[0]); 
        }
    </script>
</head>
<body>
    <div class="top-nav">
        <div class="logo-container">
            <img src="images/logo.png" alt="Logo" class="logo">
        </div>
        <div class="nav-buttons-container">
            <button class="nav-button" onclick="window.location.href='Home.php'">HOME</button>
            <button class="nav-button" onclick="window.location.href='report.php'">REPORT</button>
            <button class="nav-button" onclick="window.location.href='Notification.php'">NOTIFICATION</button>
            <button class="nav-button" onclick="window.location.href='send_message.php'">MESSAGE</button>
            <button class="nav-button" onclick="window.location.href='profile.php'">PROFILE</button>
            <button class="nav-button" onclick="window.location.href='logout.php'">LOG OUT</button>
        </div>
    </div>

    <div class="profile-container">
        <div class="profile-header">
            <h1>Change Profile Picture</h1>
        </div>

        <div class="profile-avatar">
            <img src="images/avatar.png" alt="User Avatar" id="avatar">
        </div>

        <div class="change-photo">
            <form action="upload.php" method="POST" enctype="multipart/form-data">
                <input type="hidden" id="selected-avatar" name="selected-avatar" value="">
                <label for="file-upload" class="file-upload-label">Change Photo:</label>
                <input type="file" id="file-upload" name="file-upload" accept="image/*" onchange="previewImage(event)">
                <button type="submit" class="save-photo-button">Save</button>
            </form>
        </div>

        <div class="avatar-selection">
            <span class="avatar-label">Avatar:</span>
            <button class="avatar-button" onclick="updateAvatar('male')">Male</button>
            <button class="avatar-button" onclick="updateAvatar('female')">Female</button>
        </div>
    </div>

    <div class="footer">
        CDMIRANS@2024
    </div>
</body>
</html>
