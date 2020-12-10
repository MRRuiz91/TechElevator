import axios from 'axios';

export default {

    getAllPets() {
        return axios.get('/pets');
    },
    addPet(pet) {
        return axios.post('/pets', pet);
    }

}