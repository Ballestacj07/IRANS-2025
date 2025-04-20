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

session_start(); 
// Assume that the admin is logged in and has a role set in the session.
$admin_role = $_SESSION['role'] ?? 'admin';  // Example role check

// Fetch all distinct users who have sent messages (for the admin to see)
$sql = "SELECT DISTINCT student_no, fullname FROM messages WHERE receiver = 'admin' OR receiver IS NULL";
$users_result = $conn->query($sql);

// Handle admin response submission
if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['reply_message']) && isset($_POST['student_no'])) {
    $reply_message = $_POST['reply_message'];
    $student_no = $_POST['student_no'];
    $receiver = $student_no; // Admin is replying to the specific student

    // Insert admin's reply into the messages table
    $stmt = $conn->prepare("INSERT INTO messages (student_no, fullname, amessages, receiver) VALUES (?, ?, ?, ?)");
    $admin_name = "Admin"; // Set admin name
    $stmt->bind_param("ssss", $student_no, $admin_name, $reply_message, $receiver);

    // Execute the statement
    if ($stmt->execute()) {
        echo "<p>Reply sent successfully!</p>";
    } else {
        echo "<p>Error sending reply: " . $conn->error . "</p>";
    }

    // Close the statement
    $stmt->close();
}

// Fetch messages for a specific user (if admin selects a student)
$selected_student_no = $_GET['student_no'] ?? '';
$selected_messages = [];
if ($selected_student_no) {
    $stmt = $conn->prepare("SELECT student_no, fullname, amessages, receiver, created_at FROM messages 
                            WHERE student_no = ? OR receiver = ?");
    $stmt->bind_param("ss", $selected_student_no, $selected_student_no);
    $stmt->execute();
    $result = $stmt->get_result();
    $selected_messages = $result->fetch_all(MYSQLI_ASSOC);
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Admin Messages</title>
    <link href="css/admin_message.css" rel="stylesheet" />
</head>
<body>

<div class="top-nav">
    <div class="logo-container">
        <img src="images/logo.png" alt="Logo" class="logo">
        <span class="system-title">CDM INCIDENT REPORTS AND NOTIFICATION SYSTEM - Admin Panel</span>
    </div>
    <div class="nav-buttons-container">
        <button class="nav-button" onclick="window.location.href='admin_home.php'">HOME</button>
        <button class="nav-button" onclick="window.location.href='admin_messages.php'">MESSAGES</button>
        <button class="nav-button" onclick="window.location.href='logout.php'">LOG OUT</button>
    </div>
</div>

<!-- List of Users with Conversations -->
<div class="user-list-container">
    <h2>Conversations</h2>
    <ul>
        <?php while($user = $users_result->fetch_assoc()): ?>
            <li>
                <a href="admin_messages.php?student_no=<?php echo $user['student_no']; ?>">
                    <?php echo htmlspecialchars($user['fullname']) . " (" . htmlspecialchars($user['student_no']) . ")"; ?>
                </a>
            </li>
        <?php endwhile; ?>
    </ul>
</div>

<!-- Display Conversation with Selected User -->
<div class="messages-container">
    <?php if (!empty($selected_student_no)): ?>
        <h2>Chat with <?php echo htmlspecialchars($selected_messages[0]['fullname'] ?? 'User'); ?></h2>
        <div class="chat-box">
            <?php foreach ($selected_messages as $message): ?>
                <div class="message">
                    <div class="message-text <?php echo $message['receiver'] === 'admin' ? 'user-message' : 'admin-message'; ?>">
                        <strong><?php echo htmlspecialchars($message['fullname']); ?></strong>
                        <br><br>
                        <p><?php echo htmlspecialchars($message['amessages']); ?></p>
                        <br><br>
                        <span class="created-time"><?php echo date("Y-m-d H:i:s", strtotime($message['created_at'])); ?></span>
                    </div>
                </div>
            <?php endforeach; ?>
        </div>

        <!-- Admin Reply Form -->
        <form id="replyForm" method="post" action="admin_messages.php?student_no=<?php echo $selected_student_no; ?>" class="reply-form">
            <textarea id="reply_message" name="reply_message" rows="4" placeholder="Type your reply here..." required class="reply-input"></textarea>
            <input type="hidden" name="student_no" value="<?php echo $selected_student_no; ?>">
            <button type="submit" class="send-button">Send Reply</button>
        </form>
    <?php else: ?>
        <p>Please select a user to view and reply to their messages.</p>
    <?php endif; ?>
</div>

<?php $conn->close(); ?>
</body>
</html>
