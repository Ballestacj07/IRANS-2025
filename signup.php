<?php
ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Database connection settings
    $servername = "localhost";
    $username = "root";
    $db_password = "";
    $dbname = "cdmirans";

    // Create connection
    $conn = new mysqli($servername, $username, $db_password, $dbname);

    // Check connection
    if ($conn->connect_error) {
        die("Connection failed: " . $conn->connect_error);
    }

    // Get form inputs
    $student_no = $_POST['student_no'];
    $fullname = $_POST['fullname'];
    $email = $_POST['email'];
    $password = $_POST['password'];

    // Validate form inputs (basic validation)
    if (empty($student_no) || empty($fullname) || empty($email) || empty($password)) {
        die("All fields are required.");
    }

    // Check if student number or email already exists
    $check_stmt = $conn->prepare("SELECT student_no, email FROM client_ds WHERE student_no = ? OR email = ?");
    $check_stmt->bind_param("ss", $student_no, $email);
    $check_stmt->execute();
    $check_stmt->store_result();

    if ($check_stmt->num_rows > 0) {
        echo "Error: Student number or email is already registered.";
        $check_stmt->close();
        $conn->close();
        exit();
    }

    $check_stmt->close();

    // Hash the password
    $hashed_password = password_hash($password, PASSWORD_DEFAULT);

    // Prepare SQL statement to insert new user
    $stmt = $conn->prepare("INSERT INTO client_ds (student_no, fullname, email, password) VALUES (?, ?, ?, ?)");
    $stmt->bind_param("ssss", $student_no, $fullname, $email, $hashed_password);

    if ($stmt->execute()) {
        // Log success
        file_put_contents('log.txt', "User registered: $student_no\n", FILE_APPEND);
        echo "success"; // Return success message for App Inventor
    } else {
        echo "Error: " . $stmt->error; // Return error message for App Inventor
    }

    // Close the statement and connection
    $stmt->close();
    $conn->close();
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Sign Up - Incident Reporting</title>
    <link href="css/signup.css" rel="stylesheet">
</head>
<body>
    <div class="logo">
        <img src="images/logo.png" alt="Incident Reporting Logo">
    </div>
    <div class="signup-container">
        <h1>Sign Up</h1>

        <form action="signup.php" method="post">
            <label for="student_no">Student Number:</label>
            <input type="text" id="student_no" name="student_no" placeholder="Student no." 
            pattern="\d{2}-\d{5}" maxlength="8" title="Format: 21-01478" required>

            <label for="fullname">Full Name:</label>
            <input type="text" id="fullname" name="fullname" placeholder="Name" required>

            <label for="email">Email:</label>
            <input type="email" id="email" name="email" placeholder="Email" required>

            <label for="password">Password:</label>
            <input type="password" id="password" name="password" placeholder="Password" 
            pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).{8,}" 
            title="Password must be at least 8 characters long, and include at least one uppercase letter, one lowercase letter, one number, and one special character."
            minlength="8" required>

            <label>
                <input type="checkbox" id="newsletter" name="newsletter">
                I would like to receive your newsletter and other promotional information.
            </label>

            <input type="submit" class="signup-button" value="Sign Up">
        </form>
    </div>

    <footer class="footer">
        <p>&copy; CDMIRANS 2024</p>
    </footer>
</body>
</html>
