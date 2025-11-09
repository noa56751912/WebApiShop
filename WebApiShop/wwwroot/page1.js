
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
        const email = document.querySelector("#userName2").value;
        const password = document.querySelector("#password2").value;
        const data = { email, password };
        const response = await fetch('api/Users/Login',{
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
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
        }
    }
    catch (e) {
        alert(e)
    }

}


async function Register() { 
    try {
        const Email = document.querySelector("#userName1").value;
        const FName = document.querySelector("#firstName").value;
        const LName = document.querySelector("#lastName").value;
        const Password = document.querySelector("#password1").value;

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
           
 }
       

