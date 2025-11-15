
async function getUserData() {
    try {
        const response = await fetch("api/Users");
        if (!response.ok)
            throw new Error("error")
        else {
            const data = await response.json();
            alert(data);
        }
    }
    catch (e) {
        alert(e)
    }
    
}

async function login() {
    try {
<<<<<<< HEAD
        const Email = document.querySelector("#userName1").value;
        const password = document.querySelector("#password1").value;
        const data = { Email, password };
=======
        const email = document.querySelector("#userName2").value;
        const password = document.querySelector("#password2").value;
        const data = { email, password };
>>>>>>> ed8913a3128f6670c339bb1fe93f875e19e64361
        const response = await fetch('api/Users/Login',{
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
<<<<<<< HEAD
        //if (response.status == 404) {
            
        //}
        if (!response.ok) {
            alert("New user, please register")
            //throw Error("error")
        }
       
        else {
            const dataLogin = await response.json()
            sessionStorage.setItem('user', JSON.stringify(dataLogin))
            window.location.href = "Page2.html"
=======
        if (!response.ok) {
            throw Error("error")
        }
        if (data.status == 404) {
            alert("New user, please register")
        }
        else {
            const dataLogin = await response.json()
            sessionStorage.setItem('user', JSON.stringify(dataLogin))
            Window.location.href = "Page2.html"
>>>>>>> ed8913a3128f6670c339bb1fe93f875e19e64361
        }
    }
    catch (e) {
        alert(e)
    }

}


async function Register() { 
    try {
<<<<<<< HEAD
        const Email = document.querySelector("#userName").value;
        const FName = document.querySelector("#firstName").value;
        const LName = document.querySelector("#lastName").value;
        const Password = document.querySelector("#password").value;
=======
        const Email = document.querySelector("#userName1").value;
        const FName = document.querySelector("#firstName").value;
        const LName = document.querySelector("#lastName").value;
        const Password = document.querySelector("#password1").value;
>>>>>>> ed8913a3128f6670c339bb1fe93f875e19e64361

        const data = { Email, FName, LName, Password };

        const response = await fetch('api/Users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)

        });
        if (!response.ok) {
            throw Error("run into a problem")
        }
        const dataRegister = await response.json();
        alert("sucessfly sign in")
        console.log('Post Data: ', dataRegister)
    }
    catch (e) {
        alert(e)
    }
           
<<<<<<< HEAD
}

async function PasswordStrength() {
    
    try {
        const password = document.querySelector("#password");
        const progres = document.querySelector("#passwordScore");
        const response = await fetch('api/Password/PasswordStrength', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password)

        });
        if (!response.ok) {
            throw Error("run into a problem")
        }
        const dataRegister = await response.json();
        alert("sucessfly sign in")
        console.log('Post Data: ', dataRegister)
    }
    catch (e) {
        alert(e)
    }

}
=======
 }
>>>>>>> ed8913a3128f6670c339bb1fe93f875e19e64361
       

