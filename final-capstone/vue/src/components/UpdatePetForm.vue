<template>
  <div class=" row">
    <div class="col-sm">

      <div class="text-center">
        <h1>Update Pet Form</h1>
        <p>Need to change some things?</p>
      </div>

        <!--<div class="alert alert-danger" role="alert" v-if="updatePetErrors">{{addPetErrorMessage}}</div>
        <div class="alert alert-success" role="alert2" v-if="updatePetErrors">Pet Successfully Updated Added!</div> -->

      <b-form class="update-pet-form" @submit.prevent="updatePet">
        <b-form-group inline class = "pet-info" label="Name:" label-for="petName" description="(Required)">
          <b-form-input id="petName" v-model="petToUpdate.name" required v-bind:placeholder="petToUpdate.name"></b-form-input>
        </b-form-group>

        <b-form-group class = "pet-info" label="Breed:" label-for="breed">
          <b-form-input id="breed" v-model="petToUpdate.breed" v-bind:placeholder="petToUpdate.breed"></b-form-input>
        </b-form-group>

        <b-form-group class = "pet-info" label="Age:" label-for="petAge">
            <b-form-input id="petAge" v-model="petToUpdate.age" v-bind:placeholder="petToUpdate.age"></b-form-input>
        </b-form-group>

        <b-form-group class = "pet-info" label="Image:" label-for="petImg">
            <b-form-input id="petImg" v-model="petToUpdate.picture" v-bind:placeholder="petToUpdate.picture"></b-form-input>
        </b-form-group>

        <b-form-group class = "pet-info" label="Arrival Date:" label-for="arrivalDate">
          <b-form-datepicker id="arrivalDate" v-model="petToUpdate.arrivalDate" required v-bind:placeholder="petToUpdate.arrivalDate"></b-form-datepicker>
        </b-form-group>

        <b-form-group class = "pet-info" label="Adoption Date:" label-for="adoptionDate">
          <b-form-datepicker id="adoptionDate" v-model="petToUpdate.adoptionDate" v-bind:placeholder="petToUpdate.adoptionDate"></b-form-datepicker>
        </b-form-group>

        <b-form-group class = "pet-info" label="Adopted by:" label-for="adoptedBy" description="(Required)">
          <b-form-input id="adoptedBy" v-model="petToUpdate.adoptedBy" placeholder="New owner's name here!"></b-form-input>
        </b-form-group>

        <b-form-group class = "pet-info" label="Adoption status:" label-for="isAdopted">
          <b-form-input id="isAdopted" v-model="petToUpdate.isAdopted" placeholder="Time for a new home?"></b-form-input>
        </b-form-group>  

        <b-button type="submit" variant="warning">Submit</b-button>
        <b-button type="clear" variant="warning" @click="clearForm">Clear</b-button>
      </b-form>
    </div>
  </div>
</template>

<script>
import PetsService from '../services/PetsService'  
export default {
  data() {
    return {
      petToUpdate: {
        age : 0,
        breed : '',
        name : '',
        picture : '',
        isAdopted : 0,
        arrivalDate : '',
        adoptionDate : '',
        adoptedBy : '',
      },
      placeholderpet: {},
    }
  },
  methods: {
    updatePet() {
      PetsService
      .updatePet(this.petToUpdate)
      .then(response => {
        if (response.status == 200) {
          this.$store.commit("UPDATE_IND_PET", this.petToUpdate);
        }
      })
      .catch((error) => {
        const response = error.response;
        this.registrationErrors = true;    
        if (response.status === 400) {
          this.registrationErrorMsg = 'Bad Request: Validation Errors';
        }
      });
    }
  }
}
</script>

<style>
</style>