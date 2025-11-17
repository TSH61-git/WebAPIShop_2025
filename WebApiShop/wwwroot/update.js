const welcomeText = document.querySelector("#currentUser")

let currentUser = JSON.parse(sessionStorage.getItem('CurrentUser'))

if (!currentUser) {
    alert("אין משתמש מחובר, בבקשה התחבר מחדש");
    window.location.href = "Home.html";
}

welcomeText.textContent = "Hello To " + currentUser.userFirstName;

const emailForUpdate = document.querySelector("#userName");
const firstNameForUpdate = document.querySelector("#firstName");
const lastNameForUpdate = document.querySelector("#lastName");
const passwordForUpdate = document.querySelector("#password");

emailForUpdate.value = currentUser.userEmail;
firstNameForUpdate.value = currentUser.userFirstName;
lastNameForUpdate.value = currentUser.userLastName;
passwordForUpdate.value = currentUser.userPassword;


const update = async () => {

    const updateUser = {
        UserId: currentUser.UserId,
        UserEmail: emailForUpdate.value,
        UserFirstName: firstNameForUpdate.value,
        UserLastName: lastNameForUpdate.value,
        UserPassword: passwordForUpdate.value
    }

    try {
        const response = await fetch(`https://localhost:44367/api/User/${currentUser.userId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updateUser)
        });

        if (response.status == 400) {
            alert("העדכון לא הצליח, הסיסמא לא חזקה מספיק")
        }
        else {
            alert("הנתונים התעדכנו")
        }
    }
    catch (error) {
        console.error('Error occurred:', error);
    }

}