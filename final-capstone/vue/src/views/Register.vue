<template>
  <div id="register" class=" row">
    <div class="col-sm-4"></div>

    <div class="col-sm-4">
      <b-card class="bg-dark text-white border">
        <register-form />
      </b-card>
    </div>

    <div class="col-sm-4"></div>
  </div>
</template>

<script>
import RegisterForm from '../components/RegisterForm.vue';
export default {
  components: { RegisterForm },
  name: 'register',
};
</script>

<style>
</style>
