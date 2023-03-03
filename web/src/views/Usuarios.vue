<template>
  <div class="usuarios">
    <h1 class="title">Usuarios</h1>
    <router-view></router-view>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "Usuarios",
});
</script>

<style scoped>
.usuarios {
  padding: 1.25rem;
}
</style>
