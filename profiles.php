<?php
session_start();

$servername = "mysql-irans.alwaysdata.net";
$username = "irans";
$password = "iransdatabase@2024";
$dbname = "irans_database";

if (!isset($_GET['student_no'])) {
    echo json_encode(["error" => "Student number not provided."]);
    exit();
}

$student_no = $_GET['student_no'];

$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    echo json_encode(["error" => "Connection failed: " . $conn->connect_error]);
    exit();
}

$stmt = $conn->prepare("SELECT student_no, fullname, email, profile_photo FROM client_ds WHERE student_no = ?");
$stmt->bind_param("s", $student_no);
$stmt->execute();
$result = $stmt->get_result();

if ($result->num_rows > 0) {
    $user = $result->fetch_assoc();
    if (!$user['profile_photo']) {
        $user['profile_photo'] = 'images/avatar.png';
    }
    echo json_encode($user);
} else {
    echo json_encode(["error" => "User not found."]);
}

$stmt->close();
$conn->close();
?>
