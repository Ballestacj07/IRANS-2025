<?php
session_start();

if (!isset($_SESSION['student_no'])) {
    header("Location: login.php");
    exit();
}

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "cdmirans";


$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$student_no = $_SESSION['student_no'];
$updateQuery = "UPDATE client_ds SET profile_photo = ? WHERE student_no = ?";

if (isset($_FILES['file-upload']) && $_FILES['file-upload']['error'] === UPLOAD_ERR_OK) {
    $fileTmpPath = $_FILES['file-upload']['tmp_name'];
    $fileName = $_FILES['file-upload']['name'];
    $fileSize = $_FILES['file-upload']['size'];
    $fileType = $_FILES['file-upload']['type'];
    $fileNameCmps = explode(".", $fileName);
    $fileExtension = strtolower(end($fileNameCmps));

    $allowedFileExtensions = array('jpg', 'jpeg', 'png');

    if (in_array($fileExtension, $allowedFileExtensions)) {
        $newFileName = $student_no . '.' . $fileExtension;
        $uploadFileDir = __DIR__ . '/uploads/';
        $dest_path = $uploadFileDir . $newFileName;

        if (move_uploaded_file($fileTmpPath, $dest_path)) {
            $filePath = 'uploads/' . $newFileName;
            $stmt = $conn->prepare($updateQuery);
            $stmt->bind_param("ss", $filePath, $student_no);
            
            if ($stmt->execute()) {
                header("Location: profile.php?photo=updated");
                exit();
            } else {
                echo "Error updating profile photo.";
            }

            $stmt->close();
        } else {
            echo 'There was an error moving the uploaded file.';
        }
    } else {
        echo 'Upload failed. Allowed file types: ' . implode(',', $allowedFileExtensions);
    }
} else if (isset($_POST['selected-avatar'])) {
  
    $selectedAvatar = $_POST['selected-avatar'];
    $validAvatars = array('male.png', 'female.png');

    if (in_array($selectedAvatar, $validAvatars)) {
        $filePath = 'images/' . $selectedAvatar;
        $stmt = $conn->prepare($updateQuery);
        $stmt->bind_param("ss", $filePath, $student_no);
        
        if ($stmt->execute()) {
            header("Location: profile.php?photo=updated");
            exit();
        } else {
            echo "Error updating profile photo.";
        }

        $stmt->close();
    } else {
        echo 'Invalid avatar selection.';
    }
} else {
    echo 'There was no file uploaded or there was an upload error.';
}

$conn->close();
?>
