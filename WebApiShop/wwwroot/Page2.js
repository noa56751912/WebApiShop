const welcome = document.querySelector(".welcome")
const currentUser = JSON.parse(sessionStorage.getItem('user'));
welcome.textContent = `welcome back ${currentUser.FName}`;

async function updateUser() {
    try {
        const Email = document.querySelector("#Email").value;
<<<<<<< HEAD
        const FName = document.querySelector("#FirstName").value;
        const LName = document.querySelector("#LastName").value;
        const Password = document.querySelector("#password").value;
=======
        const FirstName = document.querySelector("#FirstName").value;
        const LastName = document.querySelector("#LastName").value;
        const password = document.querySelector("#password").value;
>>>>>>> ed8913a3128f6670c339bb1fe93f875e19e64361

        let currentUser = JSON.parse(sessionStorage.getItem('user'));
        if (!currentUser) {
            alert("No current user in sessionStorage");
            return;
        }

<<<<<<< HEAD
        const Id = currentUser.id;
        const data = { Email, FName, LName, Password: Password, Id };
=======
        const Id = currentUser.Id;
        const data = { Id, Email, FirstName, LastName, password: password };
>>>>>>> ed8913a3128f6670c339bb1fe93f875e19e64361


        console.log("PUT body:", JSON.stringify(data));

        const response = await fetch(`api/Users/${Id}`, {
            method: 'PUT',
            headers: {
<<<<<<< HEAD
                'Content-Type': 'application/json'
=======
                'contect-Type': 'application/json'
>>>>>>> ed8913a3128f6670c339bb1fe93f875e19e64361
        },
            body: JSON.stringify(data)
    });

    if (response.ok) {
        currentUser.Email = Email;
        currentUser.FirstName = FirstName;
        currentUser.LastName = LastName;
        currentUser.Password = password;
        sessionStorage.setItem('user', JSON.stringify(currentUser));
        alert("success");
    }
    else {
        const update = await response.text();
        console.error('API error:', response.status, update);
        alert("Update failed: " + response.status);
    }
}
    catch (e) {
        console.error(e);
        alert(e);
    }
}