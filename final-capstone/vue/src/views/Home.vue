<template>
  <div class="home text-white">
    <div class="alert alert-success m-3" role="alert" v-if="this.$route.query.registration">
      Thank you for applying, an administrator will review your application and notify you of your status.
    </div>
    <div class="row">
      <div class="col-sm-4">
      </div>
      <div class="col-sm-4">
        <center>
          <div><img class="img" src ="..\assets\MarvelousZooO.png" width="100%"/></div>
          <h1>Little Buddies looking for a 'Fur'ever Home</h1>
        </center>
      </div>
      <div class="col-sm-4">
      </div>
    </div>
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

<style>
</style>