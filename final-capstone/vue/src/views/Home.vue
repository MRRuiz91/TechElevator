<template>
  <div class="home bg text-white">
    <div class="alert alert-success" role="alert" v-if="this.$route.query.registration">
      Thank you for applying, an administrator will review your application and notify you of your status.
    </div>

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

<style scoped>
.bg {
    background-repeat: repeat-y;
}
</style>