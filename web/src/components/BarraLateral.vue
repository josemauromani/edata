<template>
  <header>
    <nav class="panel mt-5">
      <ul>
        <li>
          <router-link to="/usuarios" class="link">
            <i class="fas fa-users"></i>
            Usuarios
          </router-link>
        </li>
      </ul>
    </nav>
  </header>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "BarraLateral",
});
</script>
<style scoped>
h1 {
  text-align: center;
}
strong {
  color: #f95738;
}
header {
  background: #b7181e;
  width: 100%;
  height: 100vh;
  padding: 2rem;
}
@media only screen and (max-width: 768px) {
  header {
    height: auto;
  }
}
.panel li {
  margin: 8px 0;
}
.link {
  color: #fff;
}
.link:hover {
  color: #faf0ca;
}
.link.router-link-active {
  color: #faf0ca;
}
</style>
