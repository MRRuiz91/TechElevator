<template>
  <b-card v-bind:pet="pet" img-top style="max-width: 20rem;" class="mb-2 border">
    <b-card-img fluid-grow v-bind:src=pet.picture alt="Image not found"></b-card-img>

    <div>
      <b-card-title class="text-light">{{pet.name}}</b-card-title>
      <b-card-text class="text-light">Age: {{ pet.age ? pet.age: "Unknown" }}</b-card-text>
    </div>  
  </b-card>
</template>

<script>
//import PetList from '@components/PetList.vue' ??
export default {
  name: 'pet-card',
  props:["pet"]
}
</script>

<style scoped>
.border {
  border: solid w 30px
}
</style>