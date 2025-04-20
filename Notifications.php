<?php
session_start();

if (!isset($_SESSION['student_no'])) {
    echo json_encode(['error' => 'Not logged in']);
    exit();
}

$student_no = $_SESSION['student_no'];

$servername = "mysql-irans.alwaysdata.net";
$username = "irans";
$db_password = "iransdatabase@2024";
$dbname = "irans_database";

$conn = new mysqli($servername, $username, $db_password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT n.message, n.created_at 
        FROM notifications n 
        JOIN inci_reports r ON n.report_id = r.id 
        WHERE r.student_no = ? 
        ORDER BY n.created_at DESC";

$stmt = $conn->prepare($sql);
$stmt->bind_param("s", $student_no);
$stmt->execute();
$result = $stmt->get_result();

$notifications = [];
while ($row = $result->fetch_assoc()) {
    $notifications[] = [
        'message' => $row['message'],
        'created_at' => $row['created_at']
    ];
}

$stmt->close();
$conn->close();

echo json_encode($notifications);
?>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                