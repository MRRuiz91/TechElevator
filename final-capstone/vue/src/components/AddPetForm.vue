<template>
<div class=" row text-center">
    <div class="col-sm-4">
    </div>
    <div class="col-sm-4">
        <h1>New Animal Form</h1>
        <p>Lets find this animal a loving home!</p>
    <b-form class="add-pet-form" @submit.prevent="addPet">
        <b-form-group class = "pet-info" label="Name:" label-for="petName" description="(Required)">
          <b-form-input 
            id="petName"
            v-model="pet.pet_name"
            required
            placeholder="Fluffer"
          ></b-form-input>
      </b-form-group>
      <b-form-group class = "pet-info" label="Breed:" label-for="breed">
          <b-form-input 
            id="breed"
            v-model="pet.breed"
            placeholder="Pomeranian"
          ></b-form-input>
      </b-form-group>
      <b-form-group class = "pet-info" label="Age:" label-for="petAge">
          <b-form-input 
            id="petAge"
            v-model="pet.pet_age"
            placeholder="3"
          ></b-form-input>
      </b-form-group>
      <b-form-group class = "pet-info" label="Image:" label-for="petImg">
          <b-form-input 
            id="petImg"
            v-model="pet.pet_image"
            placeholder="https://pic.com/1/myBaby.jpeg"
          ></b-form-input>
      </b-form-group>
      <b-form-group class = "pet-info" label="Arrival Date:" label-for="arrivalDate" description="(Required)">
          <b-form-input 
            id="arrivalDate"
            v-model="pet.arrival_date"
            required
            placeholder="01/01/2020"
          ></b-form-input>
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
export default {
name: 'add-pet-form',
data() {
    return {
      pet : {
        pet_age : '',
        breed : '',
        pet_name : '',
        pet_image : '',
        is_adopted : 0,
        arrival_date : '',
    },
  };
}
};
</script>
<style>
</style>