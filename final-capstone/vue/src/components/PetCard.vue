<template>
  <div>
  <b-card
    title="{{pet.Name}}"
    img-src="{{pet.Picture}}"
    img-alt="{{pet.Name}}'s Photo"
    img-top
    style="max-width: 20rem;"
    class="mb-2"
  >
    <b-card-text>
      {{ pet.Age ? pet.Age: "Unknown" }}
    </b-card-text>
    <b-button href="#" variant="primary">Go somewhere</b-button>
  </b-card>
</div>
</template>

<script>
export default {
    
}
</script>

<style>

</style>