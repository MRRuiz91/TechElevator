<template>
<div>
    <p>petlist component</p>
  <pet-card v-bind:pet="pet"  v-for="pet in $store.state.availablePets" v-bind:key="pet.petId"/>
</div>
</template>

<script>
import PetCard from '@/components/PetCard.vue';
import PetsService from '../services/PetsService.js';

export default {
    name: 'pet-list',
    components: {
        PetCard
    },
    created() {
        PetsService.getAllPets().then(response => {
            this.$store.commit("UPDATE_AVAILABLE_PETS", response.data)
        })/*.catch(error=>{

        })*/
    },
    data(){
        return{
            store: this.$store.state.availablePets
        }
    }

}
</script>

<style>

</style>