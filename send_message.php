<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "cdmirans";

$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

session_start(); // Start the session to use session variables
$student_no = $_SESSION['student_no'] ?? '21-01496'; // Example student number
$fullname = $_SESSION['fullname'] ?? 'Belchez John Paul';  // Example name

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $amessages = $_POST['message']; // Message content
    $receiver = 'admin'; // Default receiver is admin

    // Prepare and bind
    $stmt = $conn->prepare("INSERT INTO messages (student_no, fullname, amessages, receiver) VALUES (?, ?, ?, ?)");
    $stmt->bind_param("ssss", $student_no, $fullname, $amessages, $receiver);

    // Execute the statement
    if ($stmt->execute()) {
        echo "<p>Message sent successfully!</p>";
    } else {
        echo "<p>Error sending message: " . $conn->error . "</p>";
    }

    $stmt->close();
}

// Fetch messages between the client and admin
$sql = "SELECT student_no, fullname, amessages, created_at FROM messages 
        WHERE (student_no = ? AND receiver = 'admin') OR (receiver = ? AND student_no = ?)
        ORDER BY id ASC";
$stmt = $conn->prepare($sql);
$stmt->bind_param("sss", $student_no, $student_no, $student_no);
$stmt->execute();
$result = $stmt->get_result();

$conn->close();
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Send Message</title>
    <link href="css/umessages.css" rel="stylesheet" />
</head>
<body>
    <!-- Top Navigation Bar -->
    <div class="top-nav">
        <div class="logo-container">
            <img src="images/logo.png" alt="Logo" class="logo">
            <span class="system-title">CDM INCIDENT REPORTS AND NOTIFICATION SYSTEM</span>
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

    <!-- Messages Container -->
    <div class="messages-container">
        <h2>Chat with Admin</h2>
        <div class="chat-box">
            <?php if ($result->num_rows > 0): ?>
                <?php while($row = $result->fetch_assoc()): ?>
                    <div class="message">
                        <?php if ($row['student_no'] === $student_no): ?>
                            <!-- User Message -->
                            <div class="user-message-container">
                                <div class="message-text user-message">
                                    <strong><?php echo htmlspecialchars($row['fullname']); ?></strong>
                                    <br><br>
                                    <p><?php echo htmlspecialchars($row['amessages']); ?></p>
                                    <br><br>
                                    <span class="created-time"><?php echo date("Y-m-d H:i:s", strtotime($row['created_at'])); ?></span>
                                </div>
                            </div>
                        <?php else: ?>
                            <!-- Admin Message -->
                            <div class="admin-message-container">
                                <div class="message-text admin-message">
                                    <strong><?php echo htmlspecialchars($row['fullname']); ?></strong>
                                    <br><br>
                                    <p><?php echo htmlspecialchars($row['amessages']); ?></p>
                                    <br><br>
                                    <span class="created-time"><?php echo date("Y-m-d H:i:s", strtotime($row['created_at'])); ?></span>
                                </div>
                            </div>
                        <?php endif; ?>
                    </div>
                <?php endwhile; ?>
            <?php else: ?>
                <p>No messages found.</p>
            <?php endif; ?>
        </div>
    </div>

    <!-- Message Input Form -->
    <form id="messageForm" method="post" action="send_message.php" class="message-form">
        <textarea id="message" name="message" rows="4" placeholder="Type your message here..." required class="message-input"></textarea>
        <button type="submit" class="send-button">Send Message</button>
    </form>
</body>
</html>
     