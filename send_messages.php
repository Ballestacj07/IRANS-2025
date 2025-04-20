<?php
session_start();

// Check if a message is provided
if (isset($_GET['message']) && !empty($_GET['message'])) {
    $message = htmlspecialchars($_GET['message']);
    
    
    $servername = "mysql-irans.alwaysdata.net"; 
    $username =  "irans"; 
    $password = "iransdatabase@2024"; 
    $dbname = "irans_database";  

    // Create a connection
    $conn = new mysqli($servername, $username, $password, $dbname);

    // Check the connection
    if ($conn->connect_error) {
        echo "error"; // Return error if database connection fails
        exit;
    }

    // Insert the message into the database
    $sql = "INSERT INTO messages (content) VALUES ('$message')";
    if ($conn->query($sql) === TRUE) {
        $_SESSION['message_sent'] = true; // Set a session variable for success
        echo "success"; // Respond to the app
    } else {
        echo "error"; // Respond to the app if query fails
    }

    // Close the connection
    $conn->close();
} else {
    echo "error"; // Respond to the app if no message is provided
}
?>
