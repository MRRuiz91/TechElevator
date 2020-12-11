<template>
<div class=" row">
    <div class="col-sm">
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
        <div
          class="alert alert-success"
          role="alert2"
          v-if="addPetSuccess"
          >Pet Successfully Added!
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
      <b-button type="submit" variant="warning">
            Submit
      </b-button>
      <b-button type="clear" variant="warning" @click="clearForm">
            Clear
      </b-button>
      </b-form>
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
        age : 0,
        breed : '',
        name : '',
        picture : '',
        isAdopted : 0,
        arrivalDate : '',
    },
    addPetSuccess: false,
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
                  this.addPetSuccess = response;
                  this.clearform();
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
  clearForm() {
        this.newPet.age = 0,
        this.newPet.breed = ''
        this.newPet.name = '';
        this.newPet.picture = '';
        this.newPet.isAdopted = 0;
        this.newPet.arrivalDate = '';
        this.addPetSuccess = false;
        this.addPetErrors = false;
        this.addPetErrorMessage ='There adding this pet was unsuccessful.';
    },
  
}
};
</script>
<style>
</style>