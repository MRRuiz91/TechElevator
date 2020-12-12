import axios from 'axios';

export default {
    //Clarify with the Matts and Katie on whether or not to keep 2 separate GET methods
    getAvailablePets() {return axios.get('/pets');},

    addPet(pet) {return axios.post('/pets', pet);},
    
    updatePet(pet) {return axios.put(`/pets/${pet.id}`, pet);},

    getAllPets() {return axios.get('/pets/all');}
}