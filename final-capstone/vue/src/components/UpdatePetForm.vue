<template>
  <div class="row">
    <div class="col-sm">

      <div class="text-center">
        <h1>Update Pet Form</h1>
        <p>Need to change some things?</p>
      </div>

        <!--<div class="alert alert-danger" role="alert" v-if="updatePetErrors">{{addPetErrorMessage}}</div>-->
      <div class="alert alert-success" role="alert" v-if="updatePetSuccess">Pet Successfully Updated!</div> 

      <b-form class="update-pet-form" @submit.prevent="updatePet">
        <b-form-group inline class = "pet-info" label="Name:" label-for="petName" description="(Required)">
          <b-form-input id="petName" v-model="$store.state.selectedPet.name" required v-bind:placeholder="$store.state.selectedPet.name"></b-form-input>
        </b-form-group>

        <b-form-group class = "pet-info" label="Breed:" label-for="breed">
          <b-form-input id="breed" v-model="$store.state.selectedPet.breed" v-bind:placeholder="$store.state.selectedPet.breed"></b-form-input>
        </b-form-group>

        <b-form-group class = "pet-info" label="Age:" label-for="petAge">
            <b-form-input id="petAge" v-model="$store.state.selectedPet.age" v-bind:placeholder="$store.state.selectedPet.age"></b-form-input>
        </b-form-group>

        <b-form-group class = "pet-info" label="Image:" label-for="petImg">
            <b-form-input id="petImg" v-model="$store.state.selectedPet.picture" v-bind:placeholder="$store.state.selectedPet.picture"></b-form-input>
        </b-form-group>

        <b-form-group class = "pet-info" label="Arrival Date:" label-for="arrivalDate">
          <b-form-datepicker id="arrivalDate" v-model="$store.state.selectedPet.arrivalDate" required v-bind:placeholder="$store.state.selectedPet.arrivalDate"></b-form-datepicker>
        </b-form-group>

        <b-form-group class = "pet-info" label="Adoption Date:" label-for="adoptionDate">
          <b-form-datepicker id="adoptionDate" v-model="$store.state.selectedPet.adoptionDate" v-bind:placeholder="$store.state.selectedPet.adoptionDate"></b-form-datepicker>
        </b-form-group>

        <b-form-group class = "pet-info" label="Adopted by:" label-for="adoptedBy" description="(Required)">
          <b-form-input id="adoptedBy" v-model="$store.state.selectedPet.adoptedBy" placeholder="New owner's name here!"></b-form-input>
        </b-form-group>

        <b-form-group class = "pet-info" label="Adoption status:" label-for="isAdopted">
          <b-form-select id="isAdopted" v-model="$store.state.selectedPet.isAdopted" placeholder="Time for a new home?">
            <template #first>
               <b-form-select-option :value="null" disabled>-- Please select an option --</b-form-select-option>
            </template>
            <b-form-select-option :value="true">Adopted</b-form-select-option>
            <b-form-select-option :value="false">Not Adopted</b-form-select-option>
          </b-form-select>
        </b-form-group>  

        <b-button type="submit" variant="dark border">Submit</b-button>
        <b-button type="clear" variant="dark border" @click="clearForm">Clear</b-button>
      </b-form>
    </div>
  </div>
</template>

<script>
import PetsService from '../services/PetsService';

export default {
  data() {
    return {
      updatePetSuccess : false,
      resetPet : [{}],
    }
  },
  methods: {
    updatePet() {
      PetsService
      .updatePet(this.$store.state.selectedPet)
      .then(response => {
        if (response.data == true) {
          this.updatePetSuccess = true;
          this.$store.commit("UPDATE_IND_PET", this.store.state.selectedPet);
        }
      })
      .catch((error) => {
        const response = error.response;
        this.registrationErrors = true;    
        if (response.status === 400) {
          this.registrationErrorMsg = 'Bad Request: Validation Errors';
        }
      });
    },
    clearForm() {
      this.$store.commit('SELECT_PET', this.resetPet);
      this.updatePetSuccess = false;
      this.$router.go(0);
    }
  }
}
</script>

<style>
</style>