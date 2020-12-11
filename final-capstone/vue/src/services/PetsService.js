import axios from 'axios';

export default {

    getAvailablePets() {
        return axios.get('/pets');
    },
    addPet(pet) {
        return axios.post('/pets', pet);
    },
    updatePet(pet) {
        return axios.put(`/pets/${pet.id}`, pet);
    },
    getAllPets() {
        return axios.get('/pets/all');
    }

}