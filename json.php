<?php
session_start();

// Enable error reporting
ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

// Database connection
$servername = "localhost";
$username = "root";
$db_password = "";
$dbname = "cdmirans";

// Create connection
$conn = new mysqli($servername, $username, $db_password, $dbname);

// Check connection
if ($conn->connect_error) {
    echo json_encode(array("success" => false, "message" => "Connection failed: " . $conn->connect_error));
    exit();
}

// Process login if POST request is made
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $student_no = $_POST['student_no'];
    $password = $_POST['password'];

    // SQL statement to check the user
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

            // Return success JSON response
            echo json_encode(array(
                "success" => true,
                "student_no" => $db_student_no,
                "fullname" => $db_fullname,
                "email" => $db_email
            ));
        } else {
            // Invalid password response
            echo json_encode(array("success" => false, "message" => "Invalid password."));
        }
    } else {
        // Student not found response
        echo json_encode(array("success" => false, "message" => "Student number not found."));
    }

    $stmt->close();
}

$conn->close();
?>
