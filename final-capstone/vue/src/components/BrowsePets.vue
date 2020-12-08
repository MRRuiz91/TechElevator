<template>
    <div>
        <h1>{{pet.Name}}</h1>
        <!--<img src="{{pet.Picture}}" alt="image not found."/>-->
    </div>
  
</template>

<script>
//import PetsService from '@/services/PetsService.js';

export default {
    props: ['pet']
}
</script>

<style>

</style>