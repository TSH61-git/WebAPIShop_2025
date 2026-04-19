const emailForUpdate = document.querySelector("#userName");
const firstNameForUpdate = document.querySelector("#firstName");
const lastNameForUpdate = document.querySelector("#lastName");
const passwordForUpdate = document.querySelector("#password");

// --- פונקציית הרשמה ---
const register = async () => {
    // בניית האובייקט בהתאם ל-DTO בשרת (UserRegisterDTO)
    const newUser = {
        email: emailForUpdate.value,
        firstName: firstNameForUpdate.value,
        lastName: lastNameForUpdate.value,
        password: passwordForUpdate.value
    };

    try {
        // הכתובת תוקנה מ- api/User ל- api/User/register
        const response = await fetch('https://localhost:44367/api/User/register', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newUser)
        });

        if (response.ok) {
            alert("נרשמת בהצלחה!");
        } else {
            // טיפול בשגיאות מהשרת (למשל 400 Bad Request)
            const errorData = await response.text();
            alert("יש בעיה בהרשמה: " + errorData);
        }
    } catch (error) {
        alert("שגיאת תקשורת: " + error.message);
        console.error('Error occurred:', error);
    }
};

const loginUserEmail = document.querySelector("#loginUserName");
const loginUserPassword = document.querySelector("#loginUserPassword");

// --- פונקציית התחברות ---
const login = async () => {
    const loginUser = {
        Email: loginUserEmail.value,
        Password: loginUserPassword.value
    };

    try {
        const response = await fetch('https://localhost:44367/api/User/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(loginUser)
        });

        if (response.ok && response.status !== 204) {
            const user = await response.json();
            sessionStorage.setItem('CurrentUser', JSON.stringify(user));
            window.location.href = "update.html";
        } else {
            alert("שם משתמש או סיסמה שגויים 😕");
        }
    } catch (error) {
        console.error('Error occurred:', error);
        alert("שגיאה בחיבור לשרת");
    }
};

// --- פונקציית בדיקת חוזק סיסמה ---
const checkStrength = async () => {
    const password = passwordForUpdate.value;
    const passwordObj = {
        Pass: password,
        Strength: 0
    };

    try {
        const response = await fetch('https://localhost:44367/api/Password', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(passwordObj)
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const result = await response.json();
        const score = Number(result.strength);
        const bar = document.getElementById("progressBar");

        // עדכון פס ההתקדמות (בהנחה והניקוד הוא בין 1 ל-4)
        bar.value = score * 25;
    } catch (error) {
        console.error('Error occurred:', error);
    }
};