<template>
<div>
  <pet-card v-bind:pet="pet"  v-for="pet in $store.state.availablePets" v-bind:key="pet.petId">
</div>
</template>

<script>
import PetCard from '@/components/PetCard.vue';
import PetsService from '@/services/PetsService.vue';

export default {
    name: 'pet-list',
    components: {
        PetCard
    },
    created() {
        PetsService.getAllPets().then(response => {}).catch(error=>{})
    }

}
</script>

<style>

</style>