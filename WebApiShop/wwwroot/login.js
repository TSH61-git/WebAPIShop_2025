const emailForUpdate = document.querySelector("#userName");
const firstNameForUpdate = document.querySelector("#firstName");
const lastNameForUpdate = document.querySelector("#lastName");
const passwordForUpdate = document.querySelector("#password");


const register = async () => {
    const newUser = {
        userId: 0,
        UserEmail: emailForUpdate.value,
        UserFirstName: firstNameForUpdate.value,
        UserLastName: lastNameForUpdate.value,
        UserPassword: passwordForUpdate.value
    }


    try {
        const response = await fetch('https://localhost:44367/api/Users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newUser)
        })
        if (response.ok) {
            alert("נרשמת בהצלחה!");
        }
        else
            alert("יש בעיה בהרשמה, נסה שוב..");
    }
    catch (error) {
        console.error('Error occurred:', error);
    }
    
    
}


const loginUserEmail = document.querySelector("#loginUserName");
const loginUserPassword = document.querySelector("#loginUserPassword");

const login = async () => {
    const loginUser = {
        loginUserEmail: loginUserEmail.value,
        loginUserPassword: loginUserPassword.value,
    }

    try {
        const response = await fetch('https://localhost:44367/api/Users/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(loginUser)
        })

        if (response.ok && response.status !== 204) {
            const user = await response.json();
            sessionStorage.setItem('CurrentUser', JSON.stringify(user))
            window.location.href = "update.html"
        }
        else {
            alert("משתמש לא נמצא 😕");
            }
    }
    catch (error) {
        console.error('Error occurred:', error);
    }
}




