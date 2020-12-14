<template>
    <div class= "pet-container">
        <b-card-group deck>
        <pet-card class= "card bg-dark" v-bind:pet="pet"  v-for="pet in $store.state.availablePets" v-bind:key="pet.petId"/>
        </b-card-group>
    </div>
</template>

<script>
import PetCard from '@/components/PetCard.vue';
import PetsService from '../services/PetsService.js';
export default {
    name: 'pet-list',
    components: {PetCard},
    created() {
        PetsService.getAvailablePets().then(response => {
            this.$store.commit("UPDATE_AVAILABLE_PETS", response.data)
        })/*.catch(error=>{

        })*/
    },
    computed: {
        fillList() {return this.$store.state.availablePets} 
    }
}
</script>

<style scoped>
.pet-container {
    display:flex;
    justify-content: space-evenly;
    flex-wrap: wrap;
}
</style>