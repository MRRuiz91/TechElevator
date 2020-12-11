<template>
<div class=" row">
    <div class="col-sm-4">
    </div>
    <div class="col-sm-4">
        <div class="text-center">
          <h1>New Animal Form</h1>
          <p>Lets find this animal a loving home!</p>
        </div>
        <div
          class="alert alert-danger"
          role="alert"
          v-if="addPetErrors"
          >{{addPetErrorMessage}}
        </div>
      <b-form  class="add-pet-form" @submit.prevent="addPet">
        <b-form-group inline class = "pet-info" label="Name:" label-for="petName" description="(Required)">
          <b-form-input 
            id="petName"
            v-model="newPet.name"
            required
            placeholder="Fluffer"
          ></b-form-input>
      </b-form-group>
      <b-form-group class = "pet-info" label="Breed:" label-for="breed">
          <b-form-input 
            id="breed"
            v-model="newPet.breed"
            placeholder="Pomeranian"
          ></b-form-input>
      </b-form-group>
      <b-form-group class = "pet-info" label="Age:" label-for="petAge">
          <b-form-input 
            id="petAge"
            v-model="newPet.age"
            placeholder="3"
          ></b-form-input>
      </b-form-group>
      <b-form-group class = "pet-info" label="Image:" label-for="petImg">
          <b-form-input 
            id="petImg"
            v-model="newPet.picture"
            placeholder="https://pic.com/1/myBaby.jpeg"
          ></b-form-input>
      </b-form-group>
      <b-form-group class = "pet-info" label="Arrival Date:" label-for="arrivalDate" description="(Required)">
          <b-form-datepicker 
            id="arrivalDate"
            v-model="newPet.arrivalDate"
            required
            placeholder="01/01/2020"
          ></b-form-datepicker>
      </b-form-group>
      <b-form-group class="submission-details" label="Add another pet?" label-for="anotherPet">
          <b-form-checkbox 
            id="anotherPet" 
            v-model="addAnotherPet"
          ></b-form-checkbox>  
      </b-form-group>
      <b-button type="submit" variant="warning">
            Submit
      </b-button>
      </b-form>
    </div>
    <div class="col-sm-4">
    </div>
</div>
</template>
<script>
import PetsService from '../services/PetsService';
export default {
name: 'add-pet-form',
data() {
    return {
      newPet : {
        age : '',
        breed : '',
        name : '',
        picture : '',
        isAdopted : 0,
        arrivalDate : '',
    },
    returnResponse: '',
    addAnotherPet: false,
    addPetErrors: false,
    addPetErrorMessage: 'There were problems adding this pet.',
  };
},
methods: {
    addPet() {
      let ageInt = parseInt(this.newPet.age)
      
      if (!isNaN(ageInt) && ageInt >= 0){
        PetsService
            .addPet(this.newPet)
            .then(response => {
                this.returnResponse = response.data;
                if (response.status && this.addAnotherPet == false) {
                    this.$store.commit('TOGGLE_ADD_PET_FORM');
                }
                      
                })
            .catch(error => {
                const response = error.response;
                this.addPetErrors = true;
                if (response.status === 400) {
                    this.addPetErrorMessage = 'Bad Request: Validation Errors';
                }
            });
      }
      else {
        this.addPetErrors = true;
        this.addPetErrorMessage = "Age must an integer please try again";
      }
  },
}
};
</script>
<style>
</style>