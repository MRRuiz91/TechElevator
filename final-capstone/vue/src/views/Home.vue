<template>
  <div class="home">
    <center><h1>Little Buddies looking for a 'Fur'ever Home</h1></center>
    <pet-list/>
  </div>
</template>

<script>
import PetList from '../components/PetList.vue';

export default {
  components: { PetList },
  name: 'home',
};
</script>
