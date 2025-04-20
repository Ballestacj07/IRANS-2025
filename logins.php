<?php
// Database configuration
$servername = "mysql-irans.alwaysdata.net"; // Your database host
$username = "irans"; // Your database username
$password = "iransdatabase@2024"; // Your database password
$dbname = "irans_database"; // Your database name

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die(json_encode(array("success" => false, "message" => "Connection failed: " . $conn->connect_error)));
}

// Get data from POST request
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $student_no = $_POST['student_no'];
    $pass = $_POST['password'];

    // Validate inputs
    if (empty($student_no) || empty($pass)) {
        echo json_encode(array("success" => false, "message" => "Student number and password are required."));
        exit;
    }

    // Prepare and bind
    $stmt = $conn->prepare("SELECT student_no, password FROM client_ds WHERE student_no = ? LIMIT 1");
    $stmt->bind_param("s", $student_no);
    $stmt->execute();
    $result = $stmt->get_result();

    // Check if student exists
    if ($result->num_rows > 0) {
        $row = $result->fetch_assoc();
        
        // Verify the password (passwords must be hashed in the database)
        if (password_verify($pass, $row['password'])) {
            // Password is correct
            echo json_encode(array("success" => true, "message" => "Login successful.", "student_no" => $row['student_no']));
        } else {
            // Wrong password
            echo json_encode(array("success" => false, "message" => "Incorrect password."));
        }
    } else {
        // Student not found
        echo json_encode(array("success" => false, "message" => "Student not found."));
    }

    $stmt->close();
} else {
    echo json_encode(array("success" => false, "message" => "Invalid request method."));
}

$conn->close();
?>