const welcomeText = document.querySelector("#currentUser")
let currentUser = JSON.parse(sessionStorage.getItem('CurrentUser'))

if (!currentUser) {
    alert("אין משתמש מחובר");
    window.location.href = "login.html";
}

// תצוגת שם - בודק גם אות גדולה וגם קטנה ליתר ביטחון
welcomeText.textContent = "שלום ל- " + (currentUser.firstName || currentUser.FirstName);

const emailForUpdate = document.querySelector("#userName");
const firstNameForUpdate = document.querySelector("#firstName");
const lastNameForUpdate = document.querySelector("#lastName");
const passwordForUpdate = document.querySelector("#password");

// מילוי הנתונים הקיימים
emailForUpdate.value = currentUser.email || currentUser.Email || "";
firstNameForUpdate.value = currentUser.firstName || currentUser.FirstName || "";
lastNameForUpdate.value = currentUser.lastName || currentUser.LastName || "";

// פונקציית בדיקת חוזק (ללא שינוי)
const checkStrength = async () => {
    const password = passwordForUpdate.value;
    if (!password) return;
    try {
        const response = await fetch('https://localhost:44367/api/Password', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ Pass: password, Strength: 0 })
        });
        if (response.ok) {
            const result = await response.json();
            document.getElementById("progressBar").value = Number(result.strength) * 25;
        }
    } catch (e) { console.error(e); }
};

// הפונקציה הקריטית - עדכון הנתונים
const update = async () => {
    // וידוא שליפת ה-ID הנכון
    const id = currentUser.userId || currentUser.UserId;

    if (!id) {
        alert("שגיאה: לא נמצא מזהה משתמש");
        return;
    }

    // יצירת האובייקט בדיוק כפי שה-DTO מצפה (לפי ה-Controller שלך)
    const userToUpdate = {
        firstName: firstNameForUpdate.value,
        lastName: lastNameForUpdate.value,
        email: emailForUpdate.value,
        password: passwordForUpdate.value // כאן נשלחת הסיסמה החדשה
    };

    try {
        const response = await fetch(`https://localhost:44367/api/User/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            },
            body: JSON.stringify(userToUpdate)
        });

        if (response.ok) {
            alert("הנתונים עודכנו בשרת!");

            // עדכון ה-sessionStorage כדי שהשינוי ישתקף מיד
            const updatedUserSession = { ...currentUser, ...userToUpdate };
            sessionStorage.setItem('CurrentUser', JSON.stringify(updatedUserSession));

            location.reload();
        } else {
            const errorText = await response.text();
            alert("השרת דחה את העדכון: " + errorText);
        }
    } catch (error) {
        console.error('Fetch error:', error);
        alert("שגיאת תקשורת - בדוק שה-API רץ");
    }
}