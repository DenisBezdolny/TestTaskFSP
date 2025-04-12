// Loads the list of users from the API and renders the table
async function loadUsers() {
    try {
        const response = await fetch('/api/user'); // Send GET request to the API
        if (!response.ok) {
            throw new Error('Error while loading users');
        }
        const users = await response.json();
        console.log('Received users:', users); // Log the received users
        renderUserTable(users);
    } catch (error) {
        console.error('loadUsers -> error:', error);
    }
}

// Renders the table with users
function renderUserTable(users) {
    const tbody = document.querySelector('#user-table tbody');
    tbody.innerHTML = ''; // Clear the table
    users.forEach(user => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${user.id}</td>
            <td>${user.firstName}</td>
            <td>${user.lastName}</td>
            <td>${user.age}</td>
            <td>${user.email}</td>
            <td>
                <button onclick="editUser('${user.id}')">Edit</button>
                <button onclick="deleteUser('${user.id}')">Delete</button>
            </td>
        `;
        tbody.appendChild(row);
    });
}

// Handles the submission of the form for adding a new user
async function addUser(event) {
    event.preventDefault(); // Prevent the default form submission
    const form = event.target;

    // Collect data from the form
    const user = {
        firstName: form.firstName.value,
        lastName: form.lastName.value,
        age: parseInt(form.age.value),
        email: form.email.value
    };

    try {
        const response = await fetch('/api/user', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        });
        if (!response.ok) {
            throw new Error('Error while adding user');
        }
        form.reset(); // Reset the form
        loadUsers(); // Refresh the table
    } catch (error) {
        console.error('addUser -> error:', error);
    }
}

// Sends a request to delete a user
async function deleteUser(userId) {
    try {
        const response = await fetch(`/api/user/${userId}`, {
            method: 'DELETE'
        });
        if (!response.ok) {
            throw new Error('Error while deleting user');
        }
        loadUsers(); // Refresh the table after deletion
    } catch (error) {
        console.error('deleteUser -> error:', error);
    }
}

// Loads user data and opens the edit form
async function editUser(userId) {
    try {
        const response = await fetch(`/api/user/${userId}`);
        if (!response.ok) {
            throw new Error('Error while fetching user data for editing');
        }
        const user = await response.json();

        // Populate the edit form with the received data
        const form = document.getElementById('edit-user-form');
        form.editId.value = user.id;
        form.editFirstName.value = user.firstName;
        form.editLastName.value = user.lastName;
        form.editAge.value = user.age;
        form.editEmail.value = user.email;

        // Display the edit form container
        document.getElementById('edit-user-container').style.display = 'block';
    } catch (error) {
        console.error('editUser -> error:', error);
    }
}

// Handles the submission of the edit user form
async function submitEditUser(event) {
    event.preventDefault();
    const form = event.target;
    const updatedUser = {
        id: form.editId.value,
        firstName: form.editFirstName.value,
        lastName: form.editLastName.value,
        age: parseInt(form.editAge.value),
        email: form.editEmail.value
    };

    try {
        const response = await fetch(`/api/user/${updatedUser.id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(updatedUser)
        });
        if (!response.ok) {
            throw new Error('Error while updating user');
        }
        // Hide the edit form after a successful update
        document.getElementById('edit-user-container').style.display = 'none';
        loadUsers(); // Refresh the table
    } catch (error) {
        console.error('submitEditUser -> error:', error);
    }
}

// Initializes the page once the document content is loaded
document.addEventListener('DOMContentLoaded', () => {
    loadUsers(); // Load the users table

    // Bind event handler for the add user form
    const addUserForm = document.getElementById('add-user-form');
    if (addUserForm) {
        addUserForm.addEventListener('submit', addUser);
    }

    // Bind event handler for the edit user form
    const editUserForm = document.getElementById('edit-user-form');
    if (editUserForm) {
        editUserForm.addEventListener('submit', submitEditUser);
    }
});
