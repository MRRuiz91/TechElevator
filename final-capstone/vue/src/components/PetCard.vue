<template>
  <div>
    <p> petcard test</p>
  <b-card v-bind:pet="pet"
    title="pet.Name"
    img-src="pet.Picture"
    img-alt="pet.Name's Photo"
    img-top
    style="max-width: 20rem;"
    class="mb-2"
  >
    <b-card-text>
      Age: {{ pet.Age ? pet.Age: "Unknown" }}
    </b-card-text>
  </b-card>
</div>
</template>

<script>
//import PetList from '@components/PetList.vue' ??
export default {
    name: 'pet-card',
    props:["pet"],
}
</script>

<style>

</style>