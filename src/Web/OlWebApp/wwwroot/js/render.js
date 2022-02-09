const BASE_URL_PROJECTS = 'https://localhost:5004/api/v1';
const BASE_URL_REPORTS = 'https://localhost:5002/api/v1';

window.onload = function () {
    loadClients();
    loadFormClients();
    loadProjects();
}

const Toast = Swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 1500,
    timerProgressBar: true,
    didOpen: (toast) => {
        toast.addEventListener('mouseenter', Swal.stopTimer)
        toast.addEventListener('mouseleave', Swal.resumeTimer)
    }
})

// lista - clientes
const loadClients = () => {
    let btnDeleteClients = document.querySelectorAll('a[data-delete-client]');
    if (btnDeleteClients.length > 0) {
        for (const btn of btnDeleteClients) {
            btn.addEventListener('click', event => {
                event.preventDefault();
                let id = btn.dataset.id;
                deleteClient(id);
            });
        }
    }
}

const deleteClient = (clientId) => {
    fetch(`${BASE_URL_PROJECTS}/clients/${clientId}`, {
        method: 'DELETE'
    }).then(response => {
        if (!response.ok)
            throw new Error(response.statusText);
        return response.text();
    }).then(async _ => {
        await showAlert('success', 'Cliente eliminado correctamente');
        window.location.reload();
    }).catch(async _ => {
        await showAlert('error', 'Error al eliminar el cliente');
    })
}

const showAlert = async (icon, title) => {
    await Toast.fire({
        icon,
        title
    });
}

// formulario - clientes
const loadFormClients = () => {
    const form = document.getElementById('formClient');
    if (form) {
        form.addEventListener('submit', event => {
            event.preventDefault();
            if ($(form).valid())
                sendClient(new FormData(form));
        });
    }
}

const sendClient = (formData) => {
    const clientId = formData.get('ClientId');
    const isNewClient = clientId == '';
    fetch(`${BASE_URL_PROJECTS}/clients/${(isNewClient ? '' : clientId)}`, {
        method: isNewClient ? 'POST' : 'PUT',
        body: JSON.stringify({
            clientId: isNewClient ? 0 : clientId,
            name: formData.get('Name'),
            identification: formData.get('Identification'),
            address: formData.get('Address'),
            phone: formData.get('Phone'),
        }),
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(response => {
        if (!response.ok)
            throw new Error(response.statusText);
        return response.json();
    }).then(async _ => {
        await showAlert('success', `Cliente ${(isNewClient ? 'creado' : 'modificado')} correctamente`);
        window.location.href = '/';
    }).catch(async _ => {
        await showAlert('error', `Error al ${(isNewClient ? 'crear' : 'modificar')} el cliente`);
    })
}

// formulario - Proyectos
const loadProjects = () => {
    const formProject = document.getElementById('formProject');
    if (formProject) {
        formProject.addEventListener('submit', event => {
            event.preventDefault();
            if ($(formProject).valid()) {
                sendProject(formProject);
            }
        });
    }

    const formLanguage = document.getElementById('formLanguage');
    if (formLanguage) {
        formLanguage.addEventListener('submit', event => {
            event.preventDefault();
            if ($(formLanguage).valid()) {
                const targetLanguages = document.getElementById('targetLanguages');
                const formData = new FormData(formLanguage);
                const levelIdElement = document.getElementById('LevelId');
                targetLanguages.innerHTML += buildLanguege(formData.get('Description'), levelIdElement.selectedOptions[0].text, formData.get('LevelId'))
            }
        });
    }

    let btnDeleteProjects = document.querySelectorAll('a[data-delete-project]');
    if (btnDeleteProjects.length > 0) {
        for (const btn of btnDeleteProjects) {
            btn.addEventListener('click', event => {
                event.preventDefault();
                const projectId = btn.dataset.id;
                const clientId = btn.dataset.clientId;
                deleteProject(projectId, clientId);
            });
        }
    }
}

const buildLanguege = (language, level, levelId) => {
    const listColors = new Array("primary", "secondary", "success", "danger", "warning", "info", "dark");
    const template = `
        <div class="col-3">
            <div class="alert alert-${listColors[Math.floor(Math.random() * (6 - 0)) - 0]} alert-dismissible fade show rounded p-1 pe-4" role="alert">
                <h6 class="alert-heading text-center description">${language}</h6>
                <p class="mb-0 text-center">Nivel: ${level}</p>
                <span class="d-none levelId">${levelId}</span>
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>
        </div>`;
    return template;
}

const sendProject = (form) => {
    const formData = new FormData(form);
    const projectId = formData.get('ProjectId');
    const clientId = formData.get('ClientId');
    const languagesElement = Object.values(document.querySelectorAll('#targetLanguages .alert'));
    const isNewProject = projectId == '';
    fetch(`${BASE_URL_PROJECTS}/clients/${clientId}/projects/${(isNewProject ? '' : projectId)}`, {
        method: isNewProject ? 'POST' : 'PUT',
        body: JSON.stringify({
            projectId: isNewProject ? 0 : projectId,
            name: formData.get('Name'),
            price: formData.get('Price'),
            totalHours: formData.get('TotalHours'),
            startDate: formData.get('StartDate'),
            endDate: formData.get('EndDate'),
            statusId: formData.get('StatusId'),
            languages: languagesElement.map(language => {
                return {
                    description: language.querySelector('.description').textContent,
                    levelId: language.querySelector('.levelId').textContent,
                }
            })
        }),
        headers: {
            'Content-Type': 'application/json'
        }
    }).then(response => {
        if (!response.ok)
            throw new Error(response.statusText);
        return response.json();
    }).then(async _ => {
        await showAlert('success', `Proyecto ${(isNewProject ? 'creado' : 'modificado')} correctamente`);
        window.location.href = '/clientes/' + clientId + '/proyectos';
    }).catch(async _ => {
        await showAlert('error', `Error al ${(isNewProject ? 'crear' : 'modificar')} el proyecto`);
    })
}

const deleteProject = (projectId, clientId) => {
    fetch(`${BASE_URL_PROJECTS}/clients/${clientId}/projects/${projectId}`, {
        method: 'DELETE'
    }).then(response => {
        if (!response.ok)
            throw new Error(response.statusText);
        return response.text();
    }).then(async _ => {
        await showAlert('success', 'Proyecto eliminado correctamente');
        window.location.reload();
    }).catch(async _ => {
        await showAlert('error', 'Error al eliminar el proyecto');
    })
}