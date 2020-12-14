<template>
  <div class="row">
    <div class="col-sm">

        <div class="text-center">
          <h3>New Animal Form</h3>
          <p id='flavor-text'>Lets find this animal a loving home!</p>
        </div>

        <div class="alert alert-danger" role="alert" v-if="addPetErrors">{{addPetErrorMessage}}</div>
        <div class="alert alert-success" role="alert2" v-if="addPetSuccess">Pet Successfully Added!</div>

        <b-form  class="add-pet-form" @submit.prevent="addPet">
          <div class='row'>
          <div class="col-sm">
          <b-form-group  class = "pet-info" label="Name:" label-for="petName">
            <b-form-input id="petName" v-model="newPet.name" required placeholder="Enter name"></b-form-input>
          </b-form-group>
          </div>
          <div class="col-sm">
          <b-form-group  class = "pet-info" label="Breed:" label-for="breed">
            <b-form-input id="breed" v-model="newPet.breed" placeholder="Enter breed"></b-form-input>
          </b-form-group>
          </div>
          </div>
          <div class= "row">
            <div class="col-sm">
              <b-form-group class = "pet-info" label="Age:" label-for="petAge">
                <b-form-input id="petAge" v-bind="newPet.age" placeholder="Enter age"></b-form-input>
              </b-form-group>
            </div>
          <div class="col-sm">
          <b-form-group class = "pet-info" label="Image:" label-for="petImg">
            <b-form-input id="petImg" v-model="newPet.picture" placeholder="Enter image URL"></b-form-input>
          </b-form-group>
          </div>
          </div>
          <div class='row'>
          <div class="col-sm">
          </div>
          <div class="col-sm">
          <b-form-group class = "pet-info" label="Arrival Date:" label-for='arrivalDate'>
            <b-form-datepicker id="arrivalDate"  v-model="newPet.arrivalDate" required placeholder="Select Date"></b-form-datepicker>
          </b-form-group>
          </div>
          <div class="col-sm">
          </div>
          </div> 
          <div class="row">
          <div class="col-sm">
          </div>
          <div class="col-sm text-center">
          <b-button type="submit" variant="outline-success">Submit</b-button>
          &nbsp;
          <b-button type="clear" variant="outline-warning " @click="clearForm">Clear</b-button>
          </div>
          <div class="col-sm">
          </div>
          </div>
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
    }
  }
};
</script>

<style scoped>
#flavor-text {
  text-decoration-line: underline;
}
</style>
