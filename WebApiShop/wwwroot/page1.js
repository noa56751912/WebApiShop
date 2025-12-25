
async function PasswordStrength() {
    try {
        const password = document.querySelector("#password").value
        const progress = document.querySelector("#passwordScore")
        const response = await fetch("/api/Password/PasswordStrength", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password)
        });

        if (!response.ok) {
            throw Error("error")
        }
        const data = await response.json();
        console.log(data)
        progress.value = data * 25
    }
    catch (error) {
        alert(error)
    }
}


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

async function Login() {
    try {

        const Email = document.querySelector("#userName1").value;
        const password = document.querySelector("#password1").value;
        const data = { Email, password };


        const response = await fetch('/api/User/Login',{
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

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

        if (data.status == 404) {
            alert("New user, please register")
        }
       
        }
       }
          catch (e) {
            alert(e)
        }

}


async function Register() { 
    try {

        const Email = document.querySelector("#userName").value;
        const FirstName = document.querySelector("#firstName").value;
        const LastName = document.querySelector("#lastName").value;
        const Password = document.querySelector("#password").value;

      

        const data = { Email, FirstName, LastName, Password };

        const response = await fetch('api/User', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)

        });
        if (response.status == 400) {
            const responseText = await response.text()
            if (responseText == "Password")
                throw Error("Your password is too weak.")
            throw Error("Please try again")

        }
        if (!response.ok) {
            throw Error("run into a problem!!!")
        }
        const dataRegister = await response.json();
        alert("sucessfly sign in")
        console.log('Post Data: ', dataRegister)
    }
    catch (e) {
        alert(e)
    }
           

}



       

