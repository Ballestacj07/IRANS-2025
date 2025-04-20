

<?php
$servername = "localhost";
$username = "root"; 
$password = ""; 
$dbname = "cdmirans";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// Check if the request method is POST and form data is set
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    if (!empty($_POST['fullname']) && !empty($_POST['student_no']) && !empty($_POST['old_password']) && !empty($_POST['new_password'])) {
        
        $fullname = $_POST['fullname'];
        $student_no = $_POST['student_no'];
        $old_password = $_POST['old_password'];
        $new_password = password_hash($_POST['new_password'], PASSWORD_DEFAULT); // Hash the new password

        // Prepare SQL statement to get user data
        $sql = "SELECT password FROM client_ds WHERE student_no = ? AND fullname = ?";
        $stmt = $conn->prepare($sql);
        $stmt->bind_param("ss", $student_no, $fullname);
        $stmt->execute();
        $result = $stmt->get_result();

        if ($result->num_rows > 0) {
            $row = $result->fetch_assoc();
            $hashed_old_password = $row['password'];

            // Verify if the old password is correct
            if (password_verify($old_password, $hashed_old_password)) {
                // Prepare update SQL statement to change the password
                $update_sql = "UPDATE client_ds SET password = ? WHERE student_no = ? AND fullname = ?";
                $update_stmt = $conn->prepare($update_sql);
                $update_stmt->bind_param("sss", $new_password, $student_no, $fullname);

                if ($update_stmt->execute()) {
                    // Redirect to login page after successful password change
                    header("Location: login.php");
                    exit(); 
                } else {
                    echo "Error updating password: " . $conn->error;
                }
            } else {
                echo "The old password you entered is incorrect.";
            }
        } else {
            echo "No user found with that student number and full name.";
        }
    } else {
        echo "All fields are required.";
    }
}

$conn->close();
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Forgot Password - Incident Reporting</title>
    <link href="css/frpass.css" rel="stylesheet" />
    <script src="js/frpass.js"></script> 
</head>
<body>

    <div class="logo">
        <img src="images/logo.png" alt="Incident Reporting Logo">
    </div>

    <div class="login-container">
        <h1>FORGOT PASSWORD</h1>
        <form action="pass.php" method="post">
            <input type="text" name="fullname" placeholder="Full Name" required> 
            <input type="text" name="student_no" placeholder="Student No." required> 
            <input type="password" name="old_password" placeholder="Old Password" required> 
            <input type="password" name="new_password" placeholder="New Password" required> 
            <button type="submit" class="login-button">Submit</button> 
        </form>
        <a href="login.php" class="forgot-password">Back to Log In</a> 
    </div>

    <div class="footer">
        <p>CDMIRANS@2024</p>
    </div>

</body>
</html>
