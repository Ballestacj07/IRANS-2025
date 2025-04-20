<?php
session_start();

ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

// Database connection settings
$servername = "localhost";
$username = "root"; 
$db_password = "";    
$dbname = "cdmirans";

// Create database connection
$conn = new mysqli($servername, $username, $db_password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// If form is submitted, process login
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $student_no = $_POST['student_no'];
    $password = $_POST['password'];

    // Prepare SQL statement
    $stmt = $conn->prepare("SELECT student_no, fullname, email, password FROM client_ds WHERE student_no = ?");
    $stmt->bind_param("s", $student_no);
    $stmt->execute();
    $stmt->store_result();

    if ($stmt->num_rows > 0) {
        $stmt->bind_result($db_student_no, $db_fullname, $db_email, $hashed_password);
        $stmt->fetch();

        if (password_verify($password, $hashed_password)) {
            // Set session variables
            $_SESSION['student_no'] = $db_student_no;
            $_SESSION['fullname'] = $db_fullname;
            $_SESSION['email'] = $db_email;

            // Redirect to profile page
            header("Location: profile.php");
            exit();
        } else {
            $login_error = true;
        }
    } else {
        $login_error = true;
    }

    $stmt->close();
}

$conn->close();
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login - Incident Reporting</title>
    <link href="css/login.css" rel="stylesheet" />
</head>
<body>

    <div class="logo">
        <img src="images/logo.png" alt="Incident Reporting Logo">
    </div>

    <div class="login-container">
        <h1>LOG IN</h1>
        <form action="login.php" method="post">
            <input type="text" name="student_no" placeholder="Student no." required>
            <input type="password" name="password" placeholder="Password" required>
            <button type="submit" class="login-button">Log In</button>
        </form>

        <?php if (isset($login_error) && $login_error): ?>
            <script>
                alert("Invalid credentials. Please try again.");
            </script>
        <?php endif; ?>

        <a href="pass.php" class="forgot-password-link">Forgot Password?</a>
    </div>

    <div class="footer">
        <p>IRANS@2024</p>
    </div>

</body>
</html>


