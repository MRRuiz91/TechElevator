<template>
  <div class="home">
    <h1>Home</h1>
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
