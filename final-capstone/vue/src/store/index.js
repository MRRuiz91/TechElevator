import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)
/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if(currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    availablePets: [],
    allPets: [],
    selectedPet : null,
    showAddPetForm: false,
    showUpdatePetForm: false,
    volunteers: [],
    pendingApplications: [],
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    UPDATE_AVAILABLE_PETS(state, petsNotAdopted) {
      state.availablePets = petsNotAdopted;
    },
    UPDATE_PET_ROSTER(state, allPets) {
      state.allPets = allPets;
    },
    TOGGLE_ADD_PET_FORM(state) {
      state.showAddPetForm = !state.showAddPetForm;
    },
    UPDATE_IND_PET(state,petToUpdate) {
      let petIndex = state.allPets.findIndex(pet => {pet.id === petToUpdate.id});
      state.allPets[petIndex] = petToUpdate;
    },
    SELECT_PET(state, selected) {
      state.selectedPet = selected[0];
    }
  }
})
